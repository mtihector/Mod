define([], function () {

    return function (opts) {



        return {
            el: opts.el,
            templates: {
               
            },
            render: function () {
                this.el.html("");
                this.el.append("<ul class=\"menuItemsContainer\"> </ul>");

                var innerContainer = this.el.find("ul");


                innerContainer.append("<li class=\"menuHeader\">Security</li>");
                innerContainer.append("<li><a>Users</a></li>");
                innerContainer.append("<li><a>Permissions</a></li>");
                innerContainer.append("<li><a>Security Map</a></li>");

                innerContainer.append("<li class=\"menuHeader\">Tickets</li>");
                innerContainer.append("<li><a>View Tickets</a></li>");
                innerContainer.append("<li><a>Dashboard</a></li>");

            },
            init: function () {

                this.render();

            }
        }
    }

});