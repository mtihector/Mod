define(["text!app/templates/shell.html"],
    function(template) {

        return {
            

            initialize: function (container) {
                this.el = container;
                this.render();

            },


            render : function() {
                this.el.html(template);
                
                $('.scrollbar-inner').scrollbar();
                $("#toggleRight").on("click", function() {
                    if ($("#pageBaseContainer").hasClass("showRightContainer")) {
                        $("#pageBaseContainer").removeClass("showRightContainer");
                    } else {
                        $("#pageBaseContainer").addClass("showRightContainer");
                    }
                });


                $("#toggleLeft").on("click", function() {
                    if ($("#pageBaseContainer").hasClass("toggleLeftContainer")) {
                        $("#pageBaseContainer").removeClass("toggleLeftContainer");
                    } else {
                        $("#pageBaseContainer").addClass("toggleLeftContainer");
                    }
                });

            }
        }
    });