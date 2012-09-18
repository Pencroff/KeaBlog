/**
 * Created with JetBrains WebStorm.
 * File: wysibb.config
 * User: daniloff
 * Date: 08/31/12 - 11:24 PM
 */

/* global $:true */
var wysibb = wysibb || {};

wysibb.options = (function () {
    "use strict";
    var tempOption = {
        version: "1.0.2",
        bbmode: false,
        onlyBBmode: false,
        themePrefix: "dev/themes/",
        themeName: "fatcow",
        bodyClass: "",
        lang: "en",
        currentLang: null,
        //toolbar: false,
        //img upload config
        imgupload: true,
        img_uploadurl: "/iupload.php",
        img_maxwidth: 800,
        img_maxheight: 800,
        hotkeys: true,
        showHotkeys: true,
        //END img upload config
        buttons: "bold,italic,underline,strike,sup,sub,|,img,link,|,bullist,numlist,smilebox,|,fontcolor,fontsize,fontfamily,|,justifyleft,justifycenter,justifyright,|,quote,code,offtop,video,table,|,cut",
        allButtons: null,
        systr: {
            '<br/>': "\n"
        },
        customRules: {
            td: [
                ["[td]{SELTEXT}[/td]",
                    {
                        seltext: {
                            rgx: false,
                            attr: false,
                            sel: false
                        }
                    }]
            ],
            tr: [
                ["[tr]{SELTEXT}[/tr]",
                    {
                        seltext: {
                            rgx: false,
                            attr: false,
                            sel: false
                        }
                    }]
            ],
            table: [
                ["[table]{SELTEXT}[/table]",
                    {
                        seltext: {
                            rgx: false,
                            attr: false,
                            sel: false
                        }
                    }]
            ]
        },
        smileList: null,
        attrWrap: ['src', 'color', 'href'] //use becouse FF and IE change values for this attr, modify [attr] to _[attr]
    };
    tempOption.currentLang = wysibb.WBBLANG[tempOption.lang];
    tempOption.allButtons = {
        cut: {
            title: 'Cut',
            buttonHTML: '<span class="tlb-btn-cut"></span>',
            transform: {
                '<hr style="height: 3px; margin: 3px; size:3px;">': "[cut]"
            }
        },
        bold: {
            title: tempOption.currentLang.bold,
            buttonHTML: '<span class="tlb-btn-bold"></span>',
            excmd: 'bold',
            hotkey: 'ctrl+b',
            transform: {
                '<strong>{SELTEXT}</strong>': "[b]{SELTEXT}[/b]"
            }
        },
        italic: {
            title: tempOption.currentLang.italic,
            buttonHTML: '<span class="tlb-btn-italic"></span>',
            excmd: 'italic',
            hotkey: 'ctrl+i',
            transform: {
                '<em>{SELTEXT}</em>': "[em]{SELTEXT}[/em]"
            }
        },
        underline: {
            title: tempOption.currentLang.underline,
            buttonHTML: '<span class="tlb-btn-underline"></span>',
            excmd: 'underline',
            hotkey: 'ctrl+u',
            transform: {
                '<ins>{SELTEXT}</ins>': "[ins]{SELTEXT}[/ins]",
            }
        },
        strike: {
            title: tempOption.currentLang.strike,
            buttonHTML: '<span class="tlb-btn-strikethroungh"></span>',
            excmd: 'strikeThrough',
            transform: {
                '<del>{SELTEXT}</del>': "[del]{SELTEXT}[/del]"
            }
        },
        sup: {
            title: tempOption.currentLang.sup,
            buttonHTML: '<span class="tlb-btn-sup"></span>',
            excmd: 'superscript',
            transform: {
                '<sup>{SELTEXT}</sup>': "[sup]{SELTEXT}[/sup]"
            }
        },
        sub: {
            title: tempOption.currentLang.sub,
            buttonHTML: '<span class="tlb-btn-sub"></span>',
            excmd: 'subscript',
            transform: {
                '<sub>{SELTEXT}</sub>': "[sub]{SELTEXT}[/sub]"
            }
        },
        link: {
            title: tempOption.currentLang.link,
            buttonHTML: '<span class="tlb-btn-link"></span>',
            modal: {
                title: tempOption.currentLang.modal_link_title,
                width: "500px",
                tabs: [{
                    input: [{
                        param: "SELTEXT",
                        title: tempOption.currentLang.modal_link_text
                    }, {
                        param: "URL",
                        title: tempOption.currentLang.modal_link_url,
                        validation: '^http(s)?://'
                    }]
                }]
            },
            transform: {
                '<a href="{URL}">{SELTEXT}</a>': "[url={URL}]{SELTEXT}[/url]"
            }
        },
        img: {
            title: tempOption.currentLang.img,
            buttonHTML: '<span class="tlb-btn-img"></span>',
            modal: {
                title: tempOption.currentLang.modal_img_title,
                width: "600px",
                tabs: [{
                    title: tempOption.currentLang.modal_img_tab1,
                    input: [{
                        param: "SRC",
                        title: tempOption.currentLang.modal_imgsrc_text,
                        validation: '^http(s)?://.*?\.(jpg|png|gif|jpeg)$'
                    }]
                    //     {
                    //         title: tempOption.currentLang.modal_img_tab2,
                    //         html: '<div id="imguploader"> <form id="fupform" class="upload" action="{img_uploadurl}" method="post" enctype="multipart/form-data" target="fupload"><input type="hidden" name="iframe" value="1"/><input type="hidden" name="idarea" value="'+id+'" /><div class="fileupload"><input id="fileupl" class="file" type="file" name="img" /><button id="nicebtn" class="wbb-button">'+tempOption.currentLang.modal_img_btn+'</button> </div> </form> </div><iframe id="fupload" name="fupload" src="about:blank" frameborder="0" style="width:0px;height:0px;display:none"></iframe></div>'
                    //     }
                }],
                onLoad: 'imgLoadModal'
            },
            transform: {
                '<img src="{SRC}" />': "[img]{SRC}[/img]",
                '<img src="{SRC}" width="{WIDTH}" height="{HEIGHT}"/>': "[img width={WIDTH},height={HEIGHT}]{SRC}[/img]"
            }
        },
        bullist: {
            title: tempOption.currentLang.bullist,
            buttonHTML: '<span class="tlb-btn-list"></span>',
            excmd: 'insertUnorderedList',
            transform: {
                '<ul>{SELTEXT}</ul>': "[list]{SELTEXT}[/list]",
                '<li>{SELTEXT}</li>': "[*]{SELTEXT}[/*]"
            }
        },
        numlist: {
            title: tempOption.currentLang.numlist,
            buttonHTML: '<span class="tlb-btn-numlist"></span>',
            excmd: 'insertOrderedList',
            transform: {
                '<ol>{SELTEXT}</ol>': "[list=1]{SELTEXT}[/list]",
                '<li>{SELTEXT}</li>': "[*]{SELTEXT}[/*]"
            }
        },
        quote: {
            title: tempOption.currentLang.quote,
            buttonHTML: '<span class="tlb-btn-quote"></span>',
            //subInsert: true,
            transform: {
                '<blockquote>{SELTEXT}</blockquote>': "[quote]{SELTEXT}[/quote]"
            }
        },
        code: {
            title: tempOption.currentLang.code,
            buttonText: '[code]',
            buttonHTML: '<span class="tlb-btn-code"></span>',
            transform: {
                '<pre>{SELTEXT}</pre>': "[code]{SELTEXT}[/code]"
            }
        },
        offtop: {
            title: tempOption.currentLang.offtop,
            buttonText: 'offtop',
            buttonHTML: '<span class="tlb-btn-offtopic"></span>',
            transform: {
                '<span style="font-size:10px;color:#ccc">{SELTEXT}</span>': "[offtop]{SELTEXT}[/offtop]"
            }
        },
        fontcolor: {
            type: "colorpicker",
            title: tempOption.currentLang.fontcolor,
            buttonHTML: '<span class="tlb-btn-fontcolor"><span class="cp-line"></span></span>',
            excmd: "foreColor",
            valueBBname: "color",
            subInsert: true,
            colors: "#000000,#444444,#666666,#999999,#b6b6b6,#cccccc,#d8d8d8,#efefef,#f4f4f4,#ffffff,-, \
                     #ff0000,#980000,#ff7700,#ffff00,#00ff00,#00ffff,#1e84cc,#0000ff,#9900ff,#ff00ff,-, \
                     #f4cccc,#dbb0a7,#fce5cd,#fff2cc,#d9ead3,#d0e0e3,#c9daf8,#cfe2f3,#d9d2e9,#ead1dc, \
                     #ea9999,#dd7e6b,#f9cb9c,#ffe599,#b6d7a8,#a2c4c9,#a4c2f4,#9fc5e8,#b4a7d6,#d5a6bd, \
                     #e06666,#cc4125,#f6b26b,#ffd966,#93c47d,#76a5af,#6d9eeb,#6fa8dc,#8e7cc3,#c27ba0, \
                     #cc0000,#a61c00,#e69138,#f1c232,#6aa84f,#45818e,#3c78d8,#3d85c6,#674ea7,#a64d79, \
                     #900000,#85200C,#B45F06,#BF9000,#38761D,#134F5C,#1155Cc,#0B5394,#351C75,#741B47, \
                     #660000,#5B0F00,#783F04,#7F6000,#274E13,#0C343D,#1C4587,#073763,#20124D,#4C1130",
            transform: {
                '<font color="{COLOR}">{SELTEXT}</font>': '[color={COLOR}]{SELTEXT}[/color]'
            }
        },
        table: {
            type: "table",
            title: tempOption.currentLang.table,
            buttonHTML: '<span class="tlb-btn-table"></span>',
            cols: 10,
            rows: 10,
            cellwidth: 15,
            transform: {
                '<td>{SELTEXT}</td>': '[td]{SELTEXT}[/td]',
                '<tr>{SELTEXT}</tr>': '[tr]{SELTEXT}[/tr]',
                '<table class="table">{SELTEXT}</table>': '[table]{SELTEXT}[/table]'
            },
            skipRules: true
        },
        fontsize: {
            type: 'select',
            title: tempOption.currentLang.fontsize,
            options: "fs_verysmall,fs_small,fs_normal,fs_big,fs_verybig"
        },
        fontfamily: {
            type: 'select',
            title: tempOption.currentLang.fontfamily,
            excmd: 'fontName',
            valueBBname: "font",
            options: [{
                title: "Arial",
                exvalue: "Arial"
            }, {
                title: "Comic Sans MS",
                exvalue: "Comic Sans MS"
            }, {
                title: "Courier New",
                exvalue: "Courier New"
            }, {
                title: "Georgia",
                exvalue: "Georgia"
            }, {
                title: "Lucida Sans Unicode",
                exvalue: "Lucida Sans Unicode"
            }, {
                title: "Tahoma",
                exvalue: "Tahoma"
            }, {
                title: "Times New Roman",
                exvalue: "Times New Roman"
            }, {
                title: "Trebuchet MS",
                exvalue: "Trebuchet MS"
            }, {
                title: "Verdana",
                exvalue: "Verdana"
            }],
            transform: {
                '<font face="{FONT}">{SELTEXT}</font>': '[font={FONT}]{SELTEXT}[/font]'
            }
        },
        smilebox: { // !!!!!
            type: 'smilebox',
            title: tempOption.currentLang.smilebox,
            buttonHTML: '<span class="tlb-btn-smilebox"></span>'
        },
        justifyleft: {
            title: tempOption.currentLang.justifyleft,
            buttonHTML: '<span class="tlb-btn-textleft"></span>',
            transform: {
                '<div align="left">{SELTEXT}</div>': '[left]{SELTEXT}[/left]'
            }
        },
        justifyright: {
            title: tempOption.currentLang.justifyright,
            buttonHTML: '<span class="tlb-btn-textright"></span>',
            transform: {
                '<div align="right">{SELTEXT}</div>': '[right]{SELTEXT}[/right]'
            }
        },
        justifycenter: {
            title: tempOption.currentLang.justifycenter,
            buttonHTML: '<span class="tlb-btn-textcenter"></span>',
            transform: {
                '<div align="center">{SELTEXT}</div>': '[center]{SELTEXT}[/center]'
            }
        },
        video: {
            title: tempOption.currentLang.video,
            buttonHTML: '<span class="tlb-btn-video"></span>',
            modal: {
                title: tempOption.currentLang.video,
                width: "600px",
                tabs: [{
                    title: tempOption.currentLang.video,
                    input: [{
                        param: "SRC",
                        title: tempOption.currentLang.modal_video_text
                    }]
                }],
                onSubmit: function (cmd, opt, queryState) {
                    $.log("Submit");
                    var url = this.$modal.find('input[name="SRC"]').val();
                    var a = url.match(/^http:\/\/www\.youtube\.com\/watch\?v=([a-z0-9]+)/i);
                    if (a && a.length == 2) {
                        var code = a[1];
                        this.insertAtCursor(this.getCodeByCommand(cmd, {
                            src: code
                        }));
                    }
                    this.closeModal();
                    return false;
                }
            },
            transform: {
                '<iframe src="http://www.youtube.com/embed/{SRC}" width="640" height="480" frameborder="0"></iframe>': '[video]http://www.youtube.com/embed/{SRC}[/video]'
            }
        },

        //select options
        fs_verysmall: {
            title: tempOption.currentLang.fs_verysmall,
            buttonText: "fs1",
            excmd: 'fontSize',
            exvalue: "1",
            transform: {
                '<font size="1">{SELTEXT}</font>': '[size=50]{SELTEXT}[/size]'
            }
        },
        fs_small: {
            title: tempOption.currentLang.fs_small,
            buttonText: "fs2",
            excmd: 'fontSize',
            exvalue: "2",
            transform: {
                '<font size="2">{SELTEXT}</font>': '[size=85]{SELTEXT}[/size]'
            }
        },
        fs_normal: {
            title: tempOption.currentLang.fs_normal,
            buttonText: "fs3",
            excmd: 'fontSize',
            exvalue: "3",
            transform: {
                '<font size="3">{SELTEXT}</font>': '[size=100]{SELTEXT}[/size]'
            }
        },
        fs_big: {
            title: tempOption.currentLang.fs_big,
            buttonText: "fs4",
            excmd: 'fontSize',
            exvalue: "4",
            transform: {
                '<font size="4">{SELTEXT}</font>': '[size=150]{SELTEXT}[/size]'
            }
        },
        fs_verybig: {
            title: tempOption.currentLang.fs_verybig,
            buttonText: "fs5",
            excmd: 'fontSize',
            exvalue: "6",
            transform: {
                '<font size="6">{SELTEXT}</font>': '[size=200]{SELTEXT}[/size]'
            }
        }
    };
    tempOption.smileList = [{
        title: tempOption.currentLang.sm1,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_smile.png" class="sm" title="' + tempOption.currentLang.sm1 + '" alt="' + tempOption.currentLang.sm1 + '">',
        bbcode: ":)"
    }, {
        title: tempOption.currentLang.sm8,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_unhappy.png" class="sm" title="' + tempOption.currentLang.sm8 + '" alt="' + tempOption.currentLang.sm8 + '">',
        bbcode: ":("
    }, {
        title: tempOption.currentLang.sm2,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_happy.png" class="sm" title="' + tempOption.currentLang.sm2 + '" alt="' + tempOption.currentLang.sm2 + '">',
        bbcode: ":D"
    }, {
        title: tempOption.currentLang.sm3,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_wink.png" class="sm" title="' + tempOption.currentLang.sm3 + '" alt="' + tempOption.currentLang.sm3 + '">',
        bbcode: ";)"
    }, {
        title: tempOption.currentLang.sm4,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_cool.png" class="sm" title="' + tempOption.currentLang.sm4 + '" alt="' + tempOption.currentLang.sm4 + '">',
        bbcode: "8)"
    }, {
        title: tempOption.currentLang.sm5,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_mad.png" class="sm" title="' + tempOption.currentLang.sm5 + '" alt="' + tempOption.currentLang.sm5 + '">',
        bbcode: ":mad:"
    }, {
        title: tempOption.currentLang.sm6,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_shocked.png" class="sm" title="' + tempOption.currentLang.sm6 + '" alt="' + tempOption.currentLang.sm6 + '">',
        bbcode: ":shock:"
    }, {
        title: tempOption.currentLang.sm7,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_angry.png" class="sm" title="' + tempOption.currentLang.sm7 + '" alt="' + tempOption.currentLang.sm7 + '">',
        bbcode: ":angry:"
    }, {
        title: tempOption.currentLang.sm9,
        img: '<img src="{themePrefix}{themeName}/img/smiles/emotion_sick.png" class="sm" title="' + tempOption.currentLang.sm9 + '" alt="' + tempOption.currentLang.sm9 + '">',
        bbcode: ":sick:"
    }];
    return tempOption;
}());
