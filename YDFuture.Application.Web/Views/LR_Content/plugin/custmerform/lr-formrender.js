﻿/*
 * Ver 8.0(http://www.learun.cn)
 * Copyright (c) 2019 亿达未来科技发展有限公司
 * 创建人：力 软-前端开 发组
 * 日 期：2017.03.22
 * 描 述：自定义表单渲染
 */
(function ($, learun) {
    "use strict";

    function getFontHtml(verify) {
        var res = "";
        switch (verify) {
            case "NotNull":
            case "Num":
            case "Email":
            case "EnglishStr":
            case "Phone":
            case "Fax":
            case "Mobile":
            case "MobileOrPhone":
            case "Uri":
                res = '<font face="宋体">*</font>';
                break;
        }
        return res;
    }
    function getTdValidatorHtml(verify) {
        var res = "";
        if (verify != "") {
            res = 'isvalid="yes" checkexpession="' + verify + '"';
        }
        return res;

    }

    $.lrCustmerFormRender = function (data) {
        var girdCompontMap = {};

        var iLen = data.length;
        var $ul;
        var $container;
        if (iLen > 1) {
            var html = '<div class="lr-form-tabs" id="lr_form_tabs">';
            html += '<ul class="nav nav-tabs"></ul></div>';
            html += '<div class="tab-content lr-tab-content" id="lr_tab_content">';
            html += '</div>';
            $('body').append(html);
            $('#lr_form_tabs').lrFormTab();
            $ul = $('#lr_form_tabs ul');
            $container = $('#lr_tab_content');
        }
        else {
            $container = $('body');
        }

        for (var i = 0; i < iLen; i++) {
            var $content = $('<div class="lr-form-wrap"></div>');
            $container.append($content);
            for (var j = 0, jLen = data[i].componts.length; j < jLen; j++) {
                var compont = data[i].componts[j];
                var $row = $('<div class="col-xs-' + (12 / parseInt(compont.proportion)) + ' lr-form-item" ></div>');
                var $title = $(' <div class="lr-form-item-title">' + compont.title + getFontHtml(compont.verify) + '</div>');
                if (compont.title != '') {
                    $row.append($title);
                }
                $content.append($row);
                var $compont = $.lrFormComponents[compont.type].renderTable(compont, $row);
                if (!!$compont && !!compont.verify && compont.verify != "") {
                    $compont.attr('isvalid', 'yes').attr('checkexpession', compont.verify);
                }
                if (compont.type == 'girdtable') {
                    girdCompontMap[compont.table] = compont;
                }
            }


            if (iLen > 1) {// 如果大于一个选项卡，需要添加选项卡，否则不需要
                $ul.append('<li><a data-value="' + data[i].id + '">' + data[i].text + '</a></li>');
                $content.addClass('tab-pane').attr('id', data[i].id);
                if (i == 0) {
                    $ul.find('li').trigger('click');
                }
            }
        }

        $('.lr-form-wrap').mCustomScrollbar({ // 优化滚动条
            theme: "minimal-dark"
        });

        return girdCompontMap;
    };

    // 验证自定义表单数据
    $.lrValidCustmerform = function () {
        var validateflag = true;
        var validHelper = learun.validator;
        $('body').find("[isvalid=yes]").each(function () {
            var $this = $(this);
            if ($this.parent().find('.lr-field-error-info').length > 0) {
                validateflag = false;
                return true;
            }

            var checkexpession = $(this).attr("checkexpession");
            var checkfn = validHelper['is' + checkexpession];
            if (!checkexpession || !checkfn) { return false; }
            var errormsg = $(this).attr("errormsg") || "";
            var value;
            var type = $this.attr('type');
            if (type == 'lrselect') {
                value = $this.lrselectGet();
            }
            else if (type == 'formselect') {
                value = $this.lrformselectGet();
            }
            else {
                value = $this.val();
            }
            var r = { code: true, msg: '' };
            if (checkexpession == 'LenNum' || checkexpession == 'LenNumOrNull' || checkexpession == 'LenStr' || checkexpession == 'LenStrOrNull') {
                var len = $this.attr("length");
                r = checkfn(value, len);
            } else {
                r = checkfn(value);
            }
            if (!r.code) {
                validateflag = false;
                $.lrValidformMessage($this, errormsg + r.msg);
            }
        });
        return validateflag;
    }

    // 获取自定义表单数据
    $.fn.lrGetCustmerformData = function () {
        var resdata = {};
        $(this).find('input,select,textarea,.lr-select,.lr-formselect,.lrUploader-wrap,.jfgrid-layout').each(function (r) {
            var $self = $(this);
            var id = $self.attr('id') || $self.attr('name');
            if (!!id) {
                var type = $self.attr('type');
                switch (type) {
                    case "checkbox":
                        if ($self.is(":checked")) {
                            if (resdata[id] != undefined && resdata[id] != '') {
                                resdata[id] += ',';
                            }
                            else {
                                resdata[id] = '';
                            }
                            resdata[id] += $self.val();
                        }
                        break;
                    case "radio":
                        if ($self.is(":checked")) {
                            resdata[id] = $self.val();
                        }
                        break;
                    case "lrselect":
                        resdata[id] = $self.lrselectGet();
                        break;
                    case "formselect":
                        resdata[id] = $self.lrformselectGet();
                        break;
                    case "lr-Uploader":
                        resdata[id] = $self.lrUploaderGet();
                        break;
                    default:
                        if ($self.hasClass('lr-currentInfo')) {
                            resdata[id] = $self[0].lrvalue;
                        }
                        else if ($self.hasClass('jfgrid-layout')) {
                            var _resdata = [];
                            var _resdataTmp = $self.jfGridGet('rowdatas');
                            for (var i = 0, l = _resdataTmp.length; i < l; i++) {
                                _resdata.push(_resdataTmp[i]);
                            }
                            resdata[id] = JSON.stringify(_resdata);
                        }
                        else {
                            var value = $self.val();
                            resdata[id] = $.trim(value);
                        }
                        break;
                }
            }
        });
        return resdata;
    }
    // 设置自定义表单数据
    $.fn.lrSetCustmerformData = function (data) {// 设置表单数据
        for (var id in data) {
            var value = data[id];
            var $obj = $('#' + id.replace('lr', '').replace(/_/g, '-'));
            if (!$obj.length || $obj.length == 0) {
                var vs = value.split(',');
                for (var i = 0, l = vs.length; i < l; i++) {
                    _setvalue(vs[i]);
                }

                function _setvalue(_value) {
                    var $obj = $('input[value="' + _value + '"]');
                    if (!!$obj.length && $obj.length > 0) {
                        if (!$obj.is(":checked")) {
                            $obj.trigger('click');
                        }
                    }
                    else {
                        setTimeout(function () {
                            _setvalue(_value);
                        }, 100);
                    }
                }
            }
            else {
                var type = $obj.attr('type');
                if ($obj.hasClass("lr-input-wdatepicker")) {
                    type = "datepicker";
                }
                switch (type) {
                    case "lrselect":
                        $obj.lrselectSet(value);
                        break;
                    case "formselect":
                        $obj.lrformselectSet(value);
                        break;
                    case "datepicker":
                        $obj.val(learun.formatDate(value, 'yyyy-MM-dd'));
                        break;
                    case "lr-Uploader":
                        $obj.lrUploaderSet(value);
                        break;
                    default:
                        if ($obj.hasClass('lr-currentInfo-user')) {
                            $obj[0].lrvalue = value;
                            $obj.val('');
                            learun.clientdata.getAsync('user', {
                                userId: value,
                                callback: function (item, op) {
                                    op.obj.val(item.F_RealName);
                                },
                                obj: $obj
                            });
                        }
                        else if ($obj.hasClass('lr-currentInfo-company')) {
                            $obj[0].lrvalue = value;
                            $obj.val('');
                            learun.clientdata.getAsync('company', {
                                key: value,
                                callback: function (_data) {
                                    op.obj.val(_data.F_FullName);
                                },
                                obj: $obj
                            });
                        }
                        else if ($obj.hasClass('lr-currentInfo-department')) {
                            $obj[0].lrvalue = value;
                            $obj.val('');
                            learun.clientdata.getAsync('departmentone', {
                                departmentId: value,
                                callback: function (item, op) {
                                    op.obj.val(item.F_FullName);
                                },
                                obj: $obj
                            });
                        }
                        else if ($obj.hasClass('lr-currentInfo-guid')) {
                            $obj[0].lrvalue = value;
                            $obj.val(value);
                        }
                        else {
                            $obj.val(value);
                        }
                        break;
                }
            }
        }
    };

})(jQuery, top.learun);