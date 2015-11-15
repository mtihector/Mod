

requirejs.config({
    baseUrl: window.urlpreffix + "Scripts/modules",

    paths: {
        lib: window.urlpreffix + "Scripts/libs",

        jquery: window.urlpreffix + "Scripts/libs/JQuery/jquery",
        underscore: window.urlpreffix + "Scripts/libs/underscore/underscore",
        knockout: window.urlpreffix + "Scripts/libs/knockout/knockout",
        bootstrap: window.urlpreffix + "Scripts/libs/Bootstrap/bootstrap",
        jqueryscrollbar: window.urlpreffix + "Scripts/libs/jqueryscrollbar/jquery.scrollbar",
        backbone: window.urlpreffix + "Scripts/libs/backbone/backbone",
        underscore: window.urlpreffix + "Scripts/libs/underscore/underscore",

        app: window.urlpreffix + "Scripts/application",
        styles: window.urlpreffix + "/Content",
        text: window.urlpreffix + "Scripts/libs/require/text",
        css: window.urlpreffix + "Scripts/libs/require/css",
        domReady: window.urlpreffix + "Scripts/libs/require/domReady",
        ace: window.urlpreffix + "Scripts/libs/ace/ace",
        aclanguage_tools: window.urlpreffix + "Scripts/libs/ace/ext-language_tools",


        'beautify': window.urlpreffix + "Scripts/libs/beautify/beautify",
        'beautify-css': window.urlpreffix + "Scripts/libs/beautify/beautify-css",
        'beautify-html': window.urlpreffix + "Scripts/libs/beautify/beautify-html",
      

        /*async: '../js/libs/require/async',
        goog: '../js/libs/require/goog',
        baseProxy: '../js/appProxies/baseProxy',
        logger: window.urlpreffix + 'js/libs/toastr/logger/logger',
        highcharts: '../js/libs/highcharts/highcharts',
        highmaps: '../js/libs/highcharts/map',
        mxMap: '../js/libs/highcharts/mx-all',
        worldMap: '../js/libs/highcharts/world',
        highchartsmore: '../js/libs/highcharts/highcharts-more',
        solidGauge: '../js/libs/highcharts/solid-gauge',
      
        'ckeditor-core': '../js/libs/ckEditor/ckeditor',
        'ckeditor-jquery': '../js/libs/ckEditor/adapters/jquery',*/


    },
    shim: {
        aclanguage_tools: {
            deps: ['ace']
        },

        'beautify-css': {
            deps: ['beautify']
        },

        'beautify-html': {
            deps: ['beautify-css']
        }

        /*  'highcharts': {
            exports: "Highcharts"
        },
        'highmaps': {
            deps: ["highcharts"],
            exports: "Highcharts.map",

        },

        'mxMap': {
            deps: ["highcharts", "highmaps"],
            exports: "MxMap"


        },
        'worldMap': {
            deps: ["highcharts", "highmaps"],
            exports: "worldMap"
        },
        'highchartsmore': {
            deps: ["highcharts"],
            exports: "highchartsmore"
        },
        'solidGauge': {
            deps: ["highcharts", "highchartsmore"],
            exports: "solidGauge"
        },

        'ckeditor-jquery': {
            deps: ['ckeditor-core']
        }
        */
    },

    urlArgs: 'bust=develo' //+ (new Date()).getTime()

});


require(["app/shellView", "jquery"], function(shell, $) {
    shell.initialize($("body"));
});


/*
require(['lib/knockout/customBindings/jqueryBindings', 'lib/knockout/customBindings/jqueryUiBindings'], function () {

    ko.validation.init({
        insertMessages: false,
        decorateInputElement: true,
        errorElementClass: 'errorInputValidation'
    });

});


*/