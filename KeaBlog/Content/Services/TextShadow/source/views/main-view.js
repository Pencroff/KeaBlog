/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 02.10.12
 * Time: 16:40
 */

/*global define:true, $:true, Backbone:true, SimpleShadow:true*/
define([
    'jquery',
    'underscore',
    'backbone',
    'source/models/main-model',
    'source/collections/simple-shadows',
    'source/views/main-param-view',
    'source/views/shadow-param-view',
    'source/views/example-view',
    'text!source/templates/main-template.html',
    'source/common'
], function ($, _, Backbone, MainModel, ShadowCollection, MainParamView, ShadowParamView, ExampleView, template, Common) {
    'use strict';
    var MainView = Backbone.View.extend({
        el: '#shadowView',
        template: _.template(template),
        events: {
            'click .add-row':	'addShadowRow'
        },
        initialize: function () {
            var collection = this.model.get('collection');
            this.mainView = new MainParamView({el: '#main-param', model: this.model});
            this.mainView.render();
            this.exampleView = new ExampleView({el: '#example', model: this.model});
            this.exampleView.render();
            collection.on('add', this.showNewShadowRow, this);
            collection.on('change', this.model.refreshStyle, this.model);
            this.model.on('change', this.render, this);
            TimeResult();
        },
        render: function () {
            this.exampleView.render();
        },
        newSimpleAttributes: function () {
            return {
                hShadow: 0,
                vShadow: 0,
                blur: 0,
                color: '000',
                fullColor: '',
                opacity: '1.0'
            };
        },
        addShadowRow: function () {
            TimeStart();
            var collection = this.model.get('collection');
            collection.create(this.newSimpleAttributes());
        },
        showNewShadowRow: function (simpleShadow) {
            var view = new ShadowParamView({ model: simpleShadow });
            view.render();
            $('#shadow-param-collection').append(view.el);
            TimeResult();
        }
    });
    return MainView;
});