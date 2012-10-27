/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 08.10.12
 * Time: 15:13
 * File: main
 */

/*global require:true*/

require.config({
    // The shim config allows us to configure dependencies for
    // scripts that do not call define() to register a module
    //urlArgs: 'cb=' + Math.random(),
    //urlArgs: 'ver=' + 3,
    baseUrl: 'Content/Services/TextShadow/',
    shim: {
        'underscore': {
            exports: '_'
        },
        'backbone': {
            deps: [
                'underscore',
                'jquery'
            ],
            exports: 'Backbone'
        }
    },
    paths: {
        jquery: 'libs/jquery/jquery',
        underscore: 'libs/underscore/underscore-lodash',
        backbone: 'libs/backbone/backbone',
        localStorage: 'libs/backbone/backbone-localstorage',
        text: 'libs/require/require-text'
    }
});

require([
    'source/models/main-model',
    'source/collections/simple-shadows',
    'source/views/main-view'
], function (MainModel, ShadowCollection, AppView) {
    'use strict';
    // Initialize the application view
    var shadowCollection = new ShadowCollection(),
        mainModel = new MainModel({collection: shadowCollection});
    new AppView({model: mainModel });
});