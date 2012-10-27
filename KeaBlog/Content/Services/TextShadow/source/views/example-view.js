/**
 * Created with JetBrains WebStorm.
 * User: Sergei Danilov
 * Date: 09.10.12
 * Time: 18:31
 * File: example-view
 */

/*global define:true*/
define([
    'jquery',
    'underscore',
    'backbone',
    'text!source/templates/example-template.html'
], function ($, _, Backbone, exampleTemplate) {
    'use strict';
    var ExampleView = Backbone.View.extend({
        template: _.template(exampleTemplate),
        initialize: function () {},
        render: function () {
            if (this.model === null) {
                return;
            }
            this.$el.html(this.template(this.model.toJSON()));
        }
    });
    return ExampleView;
});