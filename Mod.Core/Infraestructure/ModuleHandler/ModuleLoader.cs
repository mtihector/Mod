using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using Mod.Core.ModuleApi;
using SimpleInjector;

namespace Mod.Core.Infraestructure.ModuleHandler
{
    public class ModuleLoader
    {

        private readonly ICollection<IModuleActivator> _activators;
        private string _deployPath;
        

        private ILog _log;
        public ILog Log => _log ?? (_log = LogManager.GetLogger(this.GetType().FullName));


        public ModuleLoader()
        {
            
            _activators = new List<IModuleActivator>();
        }

        public void Start(Container container, string modulesPath, string deployPath)
        {
         
            _deployPath = deployPath;
            LoadCurrentModules(container, modulesPath);
        
        }


        public void Stop()
        {
            Log.Debug("Stopping modules");
            foreach (var currentActivator in _activators)
            {
                Log.Debug("Stopping module " + currentActivator.GetType().Name);
                try
                {
                    currentActivator.StopModule();
                    Log.Debug("Module " + currentActivator.GetType().Name + "  stopped");
                }
                catch (Exception exception)
                {
                    Log.Error("Exception while stopping module " + currentActivator.GetType().Name + " exception :" + exception.Message + " \r\nstacktrace : " + exception.StackTrace);
                }

            }
        }

        private string DeployModule(string module)
        {
            Log.Debug("Deploying new plugin " + module);
            var info = new FileInfo(module);
            Log.Debug("Deploying Module " + info.Name);
            string targetfile = Path.Combine(_deployPath, info.Name);
            if (File.Exists(targetfile))
            {

                Log.Debug("Module : " + module + " already exists in target folder, deleting..");
                File.Delete(targetfile);
                Log.Debug("Module : " + module + " deleted");
            }
            File.Copy(module, targetfile);
            Log.Debug("New plugin " + module + " succesfully deployed");
            return targetfile;

        }

        public void LoadCurrentModules(Container containerToBeConfigured, string path)
        {
            Log.Debug("Starting modules in plugins path");
            var files = Directory.GetFiles(path);

            //Clean deployed files
            var toDelete= Directory.GetFiles(_deployPath);
            foreach (string s in toDelete)
            {
                File.Delete(s);
            }
            
            

            foreach (string module in files.OrderBy(c=> c))
            {
                Log.Debug("Trying to load module " + module);

                try
                {
                    var targetfile = DeployModule(module);
                    LoadAssemblyIntoMemoryFromFile(targetfile);

                    Log.Debug("Module " + module + " loaded");
                }
                catch (Exception exception)
                {
                    Log.Error("Error while loading module " + module + " with excepction :" + exception.Message + " \r\n stacktrace : " + exception.StackTrace);
                }

            }
            

            List<IModuleActivator> errors  = new List<IModuleActivator>();

            foreach (IModuleActivator moduleActivator in _activators)
            {
                Log.Debug("Registering container configuration for :" + moduleActivator.GetType().FullName);
                try
                {
                    moduleActivator.RegisterConfigurations(containerToBeConfigured);
                    Log.Debug(moduleActivator.GetType().FullName + "  has been registered sucessfully");
                }
                catch (Exception e)
                {
                    Log.Error("Error while trying to configure module Activator "+ moduleActivator.GetType().FullName + " with excepction "+ e.Message + " " + e.StackTrace);
                    errors.Add(moduleActivator);
                }
                
            }


            foreach (IModuleActivator moduleActivator in _activators.Where(c=> errors.All(d=> d!=c)))
            {
                
                Log.Debug("Starting module " + moduleActivator.GetType().FullName);
                moduleActivator.StartModule(containerToBeConfigured);
                Log.Debug("Module " + moduleActivator.GetType().FullName + " has been started succesfully");
            }
            Log.Debug("Starting modules has finished");
        }



        private void LoadAssemblyIntoMemoryFromFile(string targetfile)
        {
            Log.Debug("Load new module " + targetfile + " into memory");
            Assembly a = Assembly.LoadFrom(targetfile);
            
            Container container = new Container();
            var activatorTypes = a.GetTypes().Where(c => typeof(IModuleActivator).IsAssignableFrom(c)).ToList();
            foreach (var currentActivatorType in activatorTypes)
            {
               
                Log.Debug("Activator :" + currentActivatorType.Name + " found, starting module");
                var activator = (IModuleActivator)container.GetInstance(currentActivatorType);
                _activators.Add(activator);
                Log.Debug("Activator " + currentActivatorType.Name + " completed");

            }

            Log.Debug("New module " + targetfile + " loaded successfully");
        }





    }
}



/*

    
        public void StartMonitoringFolder(string path)
        {
            //Monitoring foldes has been disable until find out how to change the container after being configuraded
            //Logger.Write("Starting file watcher", Categories.Verbose);
            //FileSystemWatcher fw = new FileSystemWatcher
            //{
            //    Path = path,
            //    NotifyFilter = NotifyFilters.LastWrite
            //                     | NotifyFilters.FileName
            //};

            //// fw.Changed += OnModuleChanged;
            ////  fw.Created += OnModuleCreated;
            ////fw.Deleted += OnModuleChanged;
            ////fw.Changed += OnModuleChanged;
            //fw.EnableRaisingEvents = true;
            //Logger.Write("Module File Watcher started", Categories.Verbose);

        }




        private bool ModuleAlreadyDeployed(string sourceFile)
        {
            FileInfo file = new FileInfo(sourceFile);
            string target = Path.Combine(_deployPath, file.Name);
            return File.Exists(target);
        }



        private void OnModuleCreated(object sender, FileSystemEventArgs e)
        {

            //todo: add replace the container if a new plugin has been loaded
            return;
            //Logger.Write("Module dropped in a plugin folder  "+ e.FullPath+ " type: "+e.ChangeType + "  trying hot deploying", Categories.Verbose);

            //Logger.Write("Checking if module already deployed", Categories.Verbose);
            //if (ModuleAlreadyDeployed(e.FullPath))
            //{
            //    Logger.Write("Module already deployed, cannot unload already loaded assemblies, you should stop the application domain (app Pool for web)",Categories.Error);
            //}
            //Logger.Write("Module not deployed,   starting deploy..");
            //var targetfile = DeployModule(e.FullPath);
            //LoadAssemblyIntoMemoryFromFile(_container, targetfile);

            //Logger.Write("Module hot deployed succesfully");

        }

    */