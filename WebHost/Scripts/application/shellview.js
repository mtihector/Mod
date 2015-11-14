"use strict";
define(["text!app/templates/shell.html", "Menu/Menu", "jquery", "jqueryscrollbar"],
    
    function(template, menu, $) {
        
        return {
            

            initialize: function (container) {
                this.el = container;
                this.render();

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


                this.initMenu();
            }
        }
    });