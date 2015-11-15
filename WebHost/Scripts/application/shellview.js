"use strict";
define(["text!app/templates/shell.html", "Menu/Menu", "jquery", "jqueryscrollbar","lib/mod/mod", "backbone", "underscore"],
    
    function(template, menu, $, jqs,mod, bb, _) {
        
        return {
            

            initialize: function (container) {
                this.el = container;
                this.render();

            },


            initRouter: function () {
                
                mod.sendQuery({
                    "$type": "Mod.Core.ModuleApi.Impl.Routes.RouteQuery, Mod.Core, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"
                }).then(function(items) {
                    var routes = {};
                    var routesHelper = {};
                    _.each(items, function(ci) {
                        routes[ci.Route] = ci.Route;
                        routesHelper[ci.Route] = function() {
                            require([ci.Controller], function(controller) {
                                var instance = new controller({
                                    el: $("#ModuleContainer")
                                });

                                instance.init();
                            });
                        };
                    });

                    routesHelper.routes = routes;
                

                    var Workspace = Backbone.Router.extend(routesHelper);

                    this.router= new Workspace();

                    //bb.history.handlers.push({
                    //    route: /(.*)/,
                    //    callback: function (fragment) {
                    //        if (fragment !== "") {
                    //            //alert(fragment);
                    //            if (routes[fragment])
                                
                    //        }
                    //    }
                    //});
                    
                    Backbone.history.start({ pushState: true });

                }.bind(this), function (error) {
                    alert("Error while loading routes: " + error);
                }.bind(this));
            },
           
            initMenu: function() {
                if (this.menu == undefined) {
                    this.menu = new menu({
                        el: $("#MenuContainer")
                    });
                }

                this.menu.init();
            },

            render : function() {
                this.el.html(template);
                
                $('.scrollbar-inner').scrollbar();
                $("#toggleRight").on("click", function() {
                    if ($("body").hasClass("showRightContainer")) {
                        $("body").removeClass("showRightContainer");
                    } else {
                        $("body").addClass("showRightContainer");
                    }
                });


                $("#toggleLeft").on("click", function() {
                    if ($("#pageBaseContainer").hasClass("toggleLeftContainer")) {
                        $("#pageBaseContainer").removeClass("toggleLeftContainer");
                    } else {
                        $("#pageBaseContainer").addClass("toggleLeftContainer");
                    }
                });


                this.initRouter();

                this.initMenu();
            }
        }
    });