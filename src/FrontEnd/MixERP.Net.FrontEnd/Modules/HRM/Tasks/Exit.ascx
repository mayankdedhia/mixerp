﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Exit.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Tasks.Exit" %>
<script>
    var scrudFactory = new Object();
    
    scrudFactory.title = "Exits";
    scrudFactory.viewPocoName = "ExitScrudView";
    scrudFactory.formPocoName = "Exit";
    scrudFactory.formTableName = "hrm.exits";

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;
    scrudFactory.excludedColumns = ["audit_user_id", "audit_ts", "entered_by"];

    scrudFactory.live = "EmployeeId";

    scrudFactory.layout = [
        ["ExitId", ""],
        ["EmployeeId", "Reason", "", ""],
        ["ChangeStatusCodeTo", "ExitTypeId", "", ""],
        ["Details", ""],
        ["ExitInterviewDetails", ""]
    ];

    scrudFactory.keys = [
        {
            property: "EmployeeId",
            url: '/api/hrm/employee/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "ExitTypeId",
            url: '/api/hrm/exit-type/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "ChangeStatusCodeTo",
            url: '/api/hrm/employment-status-code/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>

<script>
    $(document).on("formready", function() {
        $("#entered_by").val(window.userId);
    });
</script>