﻿/*
 * Ver 8.0(http://www.learun.cn)
 * Copyright (c) 2019 亿达未来科技发展有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.04.18
 * 描 述：流程加签	
 */
var acceptClick;
var auditorName = '';
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('#auditorId').lrselect({
                value: 'F_UserId',
                text: 'F_RealName',
                title: 'F_RealName',
                // 展开最大高度
                maxHeight: 190,
                // 是否允许搜索
                allowSearch: true,
                select: function (item) {
                    auditorName = item.F_RealName;
                }
            });
            $('#department').lrDepartmentSelect({
                maxHeight: 220
            }).on('change', function () {
                var value = $(this).lrselectGet();
                $('#auditorId').lrselectRefresh({
                    url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
                    param: { departmentId: value }
                });
            });
        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var formData = $('#form').lrGetFormData();



        callBack(formData);
        return true;
    };
    page.init();
}