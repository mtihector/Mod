"use strict";
define(["text!Menu/templates/MenuDemo.html",
"lib/mod/mod"], function (template, mod) {

    return function (opts) {



        return {
            el: opts.el,
            templates: {

            },
            render: function () {
                this.el.html(template);

                this.el.find("a").on("click", function (e) {
                    e.preventDefault();
                    Backbone.history.navigate($(this).attr("href"), true);
                });
                mod.sendQuery({
                    "$type": "Mod.Core.ModuleApi.Impl.Menu.MenuQuery, Mod.Core, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"
                }).then(function (items) {
                    //    alert("Received: " + items.length);
                    console.log("Received: " + items.length);
                    
                }, function (error) {
                    alert("error" + error);
                });
                //this.el.append("<ul class=\"menuItemsContainer\"> </ul>");

                //var innerContainer = this.el.find("ul");


                //innerContainer.append("<li class=\"menuHeader\">Security</li>");
                //innerContainer.append("<li><a>Users</a></li>");
                //innerContainer.append("<li><a>Permissions</a></li>");
                //innerContainer.append("<li><a>Security Map</a></li>");

                //innerContainer.append("<li class=\"menuHeader\">Tickets</li>");
                //innerContainer.append("<li><a>View Tickets</a></li>");
                //innerContainer.append("<li><a>Dashboard</a></li>");

            },
            init: function () {

                this.render();

            }
        }
    }

});