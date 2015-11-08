
define('ace/mode/lh-expressions',function (require, exports, module) {
    "use strict";

    var oop = require("../lib/oop");
    // defines the parent mode
    var TextMode = require("./text").Mode;
    //var Tokenizer = require("../tokenizer").Tokenizer;
    //var WorkerClient = require("../worker/worker_client").WorkerClient;
    var MatchingBraceOutdent = require("./matching_brace_outdent").MatchingBraceOutdent;


    var TextHighlightRules = require("./text_highlight_rules").TextHighlightRules;

    var customFunctions = require('JForms/designer/expressions/customFunctions');

    var expressionsHighlightRules = function () {
        var functionNames = new customFunctions()
            .map(function(c) { return c.name; })
            .join('|');
        var builtinFunctions = (
            functionNames
        );
        var builtinConstants = (
            "null|true|false"
        );

        var keywordMapper = this.$keywords = this.createKeywordMapper({
            "keyword": builtinFunctions,
            "constant.language": builtinConstants
        }, "identifier");



        // regexp must not have capturing parentheses. Use (?:) instead.
        // regexps are ordered -> the first match is used
        this.$rules = {
            "start": [
                {
                    token: "variable.parameter", // single line
                    regex: '_([a-zA-Z0-9])*'
                }, {
                    token: keywordMapper,
                    regex: "[a-zA-Z_][a-zA-Z0-9_]*\\b"
                }, {
                    token: "string", // single line
                    regex: '"',
                    next: "string"
                }, {
                    token: "constant.numeric", // float
                    regex: "[+-]?\\d+(?:(?:\\.\\d*)?(?:[eE][+-]?\\d+)?)?\\b"
                }, {
                    token: "invalid.ilegal", //string must be double quotes
                    regex: "['](?:(?:\\\\.)|(?:[^'\\\\]))*?[']"
                }, {
                    token: "invalid", // place holders
                    regex: "@[a-zA-Z0-9_]*"
                }, {
                    token: "paren.lparen",
                    regex: "[[(]"
                }, {
                    token: "paren.rparen",
                    regex: "[\\])]"
                }, {
                    token: "text",
                    regex: "\\s+"
                }
            ],
            "string": [
                {
                    token: "constant.language.escape",
                    regex: /\\(?:x[0-9a-fA-F]{2}|u[0-9a-fA-F]{4}|["\\\/bfnrt])/
                }, {
                    token: "string",
                    regex: '[^"\\\\]+'
                }, {
                    token: "string",
                    regex: '"',
                    next: "start"
                }, {
                    token: "string",
                    regex: "",
                    next: "start"
                }
            ]
        };


    };

    oop.inherits(expressionsHighlightRules, TextHighlightRules);



    // defines the language specific highlighters and folding rules
    
    //var MyNewFoldMode = require("./folding/mynew").MyNewFoldMode;

    var Mode = function () {
        // set everything up
        this.HighlightRules = expressionsHighlightRules;
        this.$outdent = new MatchingBraceOutdent();
        //this.foldingRules = new MyNewFoldMode();
    };
    oop.inherits(Mode, TextMode);

    (function () {
        // configure comment start/end characters
        this.lineCommentStart = "//";
        this.blockComment = { start: "/*", end: "*/" };

        // special logic for indent/outdent. 
        // By default ace keeps indentation of previous line
        this.getNextLineIndent = function (state, line, tab) {
            var indent = this.$getIndent(line);
            return indent;
        };

        this.checkOutdent = function (state, line, input) {
            return this.$outdent.checkOutdent(line, input);
        };

        this.autoOutdent = function (state, doc, row) {
            this.$outdent.autoOutdent(doc, row);
        };

        // create worker for live syntax checking
        //this.createWorker = function (session) {
        //    var worker = new WorkerClient(["ace"], "ace/mode/lh-expressions", "LhExpressions");
        //    worker.attachToDocument(session.getDocument());
        //    worker.on("errors", function (e) {
        //        session.setAnnotations(e.data);
        //    });
        //    return worker;
        //};

    }).call(Mode.prototype);

    exports.Mode = Mode;
});

