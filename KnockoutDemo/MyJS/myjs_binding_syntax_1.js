/// <reference path="jquery-3.2.1.js" />
/// <reference path="knockout-3.4.2.debug.js" />
$(function () {
    debugger;
    text_bind();
    visible_bind();
    html_bind();
    css_bind();
});

function ko_applyBindings(viewModel, id) {
    ko.applyBindings(viewModel, document.getElementById(id));
}

function text_bind() {
    var viewModel = {
        text: ko.observable("text 绑定"),
    };
    ko_applyBindings(viewModel, 'text_bind');
}

function visible_bind() {
    var viewModel = {
        visible: ko.observable(true),
        btnText: ko.observable("隐藏"),
        setBtnText: function () {
            this.visible() ? this.btnText("隐藏") : this.btnText("显示");
        },
        setVisible: function () {
            this.visible(!this.visible());
            this.setBtnText();
        },
    };
    ko_applyBindings(viewModel, 'visible_bind');
}

function html_bind() {
    var viewModel = {
        details: ko.observable(),
    };
    viewModel.details('<em>HTML 绑定替换了原内容。</em>');
    ko_applyBindings(viewModel, 'html_bind');
}

/**
 * different from 'style_bind'
 */
function css_bind() {
    var viewModel = {
        currentClass: ko.observable(),
        btnText: ko.observable("添加Class"),
        isAddClass: ko.observable(true),
        addOrMoveClass: function () {
            debugger;
            this.setClass();
            this.isAddClass(!this.isAddClass());
            this.setBtnText();
        },
        setBtnText: function () {
            debugger;
            this.isAddClass() ? this.btnText("添加 Class") : this.btnText("移除 Class");
        },
        setClass: function () {
            debugger;
            this.isAddClass() ? this.currentClass("css_bind_className") : this.currentClass("");
            
        },
    };
    ko_applyBindings(viewModel, 'css_bind');
};
