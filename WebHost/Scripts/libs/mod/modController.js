define(["jquery","underscore"], function($,_) {

    return function (template, obj) {
        

        return function(opts) {

            this.init = function() {
                //loading html to the container
                $(opts.el).html(template);

                if (this.afterBind !== undefined && _.isFunction(this.afterBind)) {
                    this.afterBind();
                } else {
                    console.log("afterbind is not setted or is not a function");
                }
            };


            for (var elem in obj) {
                if (obj.hasOwnProperty(elem)) {
                    this[elem] = obj[elem];
                }
            }


        }
            
        
    }
});