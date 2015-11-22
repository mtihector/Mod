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

             

                var menuContainer = $(this.el).find("ul");

                mod.sendQuery({
                    "$type": "Mod.Core.ModuleApi.Impl.Menu.MenuQuery, Mod.Core, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"
                }).then(function (items) {
                    
                    console.log("Received: " + items.length);
                    _.each(items, function(ci) {

                        var currentContainer= menuContainer.find("[path='" + ci.MenuPath + "']");

                        if (currentContainer.length === 0) {
                            menuContainer.append("<li class=\"menuHeader\" path=\""+ci.MenuPath+"\"><div><a>"+ci.MenuPath+"</a> <ul> </ul> </div></li>");
                            currentContainer = menuContainer.find("[path='" + ci.MenuPath + "']");
                        }


                        var innercontainer =currentContainer.find("ul");
                        innercontainer.append("<li><a href=\"/" + ci.Route + "\">" + ci.MenuItemName + "</a></li>");


                    },this);


                    menuContainer.find("a").on("click", function (e) {
                        e.preventDefault();
                        Backbone.history.navigate($(this).attr("href"), true);
                    });



                }, function (error) {
                    alert("error" + error);
                });
               
            },
            init: function () {

                this.render();

            }
        }
    }

});