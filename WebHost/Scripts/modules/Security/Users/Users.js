define(["jquery", "text!Security/Users/templates/Users.html"], function ($, template) {

    return function(opts) {
        this.init = function() {
            $(opts.el).html(template);
        }
    }
});