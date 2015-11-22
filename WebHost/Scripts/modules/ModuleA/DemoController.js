define(["text!ModuleA/template/DemoTemplate.html",
        "lib/mod/modController", "jquery"],

  function (template, mc, $) {

      //return a constructor
      //mc is a function that return a constructor function
      //so the caller of this will need to run  new functionane({opts});
      return mc(template, {
          afterBind: "123",
          afterBind1: function() {
              alert("caller ok");
          }
      });

  });