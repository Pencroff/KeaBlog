CKEDITOR.plugins.add('readmore', {
    requires: ['fakeobjects', 'htmldataprocessor'],
    init: function(editor) {
        editor.addCss('#cut' + '{' + 'background-color: #ebcccc; background-image: url(' + CKEDITOR.getUrl(this.path + 'images/readmore.png') + ');' + 'background-position: center center;' + 'background-repeat: no-repeat;' + 'clear: both;' + 'display: block;' + 'float: none;' + 'width: 100%;' + 'border-top: #FF0000 1px dashed;' + 'border-bottom: #FF0000 1px dashed;' + 'height: 5px;' + '}');
        // Register the toolbar buttons.
        editor.ui.addButton('ReadMore', {
            label: 'Insert Readmore',
            icon: this.path + 'images/cut_red.png',
            command: 'readmore'
        });
        editor.addCommand('readmore', {
            exec: function() {
                var hrs = editor.document.getElementsByTag('div');
                for (var i = 0, len = hrs.count(); i < len; i++) {
                    var hr = hrs.getItem(i);
                    if (hr.getId() == 'cut') {
                        alert('There is already a Read more... link that has been inserted. Only one such link is permitted. Use {pagebreak} to split the page up further');
                        return;
                    }
                }
                editor.insertHtml('<div id="cut">&nbsp;</div>');
            }
        });
    }
});