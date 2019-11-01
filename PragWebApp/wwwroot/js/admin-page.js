////////////////////////////////////////////
/// AdminCtrl //////////////////////////////
////////////////////////////////////////////

var app = angular.module('AdminPage', ['ngMessages', 'mgcrea.ngStrap']);

app.controller('adminCtrl', function ($scope, $http, $timeout) {

    // Global
    $scope.localizedStrings = [];

    // SelectType
    $scope.useExistingType = true;
    $scope.selectedType = { id: '1', name: '', description: '', parent: '', users: [] };
    $scope.createdType = { id: '0', name: '', description: '', parent: '', users: [] };
    $scope.activeContentType = { id: '1', name: '', description: '', parent: '', users: [] };
    $scope.selectedParent = null;
    $scope.showSelectTypeModal = false;
    $scope.showConfirmNewContentTypeModal = false;
    $scope.validationError = "";
    $scope.showFetchContentTypeProgressModal = false;
    $scope.showTypePermissionsModal = false;
    $scope.lastTypeEditedPermissions = { users: [], radio: 'A', element: '', state: '', field: '', type: '' };
    $scope.showTypePeoplePicker = false;
    $scope.previousDescription = "";
    $scope.wizardInitData = { configs: [], types: [], parents: [] };
    $scope.wizardTypeData = { type: { id: '0', name: '', description: '', users: [], parent: '', states: [], fields: [], status: 'O' } };

    // XmlFiles
    $scope.xmlFile = "";
    $scope.xmlFileName = "wizard_draft.json";
    $scope.xmlFileContent = "";
    $scope.publishResult = "";
    $scope.draftData = {};
    $scope.showPublishContentTypeModal = false;
    $scope.showPublishContentTypeProgressModal = false;
    $scope.showReplaceTypeByDraftModal = false;
    $scope.workOnline = false;

    // Properties                                                                                                          
    $scope.cellSize = 300;

    // Main
    $scope.orders = [{ key: 'displayName', text: 'Display field name' }, { key: 'order', text: 'Content type position' }];
    $scope.selectedOrder = { key: 'displayName', text: 'Display field name' };
    $scope.showStatePermissionsModal = false;
    $scope.lastEditedPermissions = { users: [], radio: 'A', element: '', state: '', field: '', type: '' };
    $scope.showPeoplePicker = false;
    $scope.elementDragged = null;
    $scope.lastDefaultState = '';

    // States
    $scope.inactiveStateCondition = { active: false }
    $scope.useExistingState = true;
    $scope.showAddStateModal = false;
    $scope.showEditStateModal = false;
    $scope.showDeleteStateModal = false;
    $scope.showChangeStateFinalFlagModal = false;
    $scope.createdState = { state: '', final: false, typeStateRelation: { default: false, order: 0, users: [], editors: [], readers: [] }, status: 'A' };
    $scope.deletingState = { state: '', final: false, typeStateRelation: { default: false, order: 0, users: [], editors: [], readers: [] }, status: 'D' };
    $scope.addedState = { state: '', final: false, typeStateRelation: { default: false, order: 0, users: [], editors: [], readers: [] }, status: 'A' };
    $scope.stateChangedFinalFlag = { state: '', final: false, typeStateRelation: { default: false, order: 0, users: [], editors: [], readers: [] }, status: 'M' };
    $scope.unusedStates = [];

    // Fields
    $scope.inactiveFieldCondition = { active: false }
    $scope.useExistingField = true;
    $scope.showAddFieldModal = false;
    $scope.showEditFieldModal = false;
    $scope.showDeleteFieldModal = false;
    $scope.createdField = { id: 1, internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'A', createdFieldDisplayName: '' };
    $scope.deletingField = { internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'D' };
    $scope.editedField = { internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'M' };
    $scope.editedFieldOriginal = { internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'M' };
    $scope.unusedFields = [];

    $scope.initData = function () {

        try {
            $scope.loadDictionary();
        } catch (error) { }

        $scope.orders = [{ key: 'displayName', text: $scope.getLocalString('WZDOrderFieldsDisplay') }, { key: 'order', text: $scope.getLocalString('WZDOrderFieldsOrder') }];
        $scope.selectedOrder = { key: 'displayName', text: $scope.getLocalString('WZDOrderFieldsDisplay') };
        $scope.showStateDdl();

        try {
            $scope.initTypes();
        } catch (error) { }

        try {
            $scope.loadWizardInitData();
        } catch (error) { }

        try {
            $scope.initDocument();
        } catch (error) { }
    };

    $scope.initDocument = function () {

        var columnHeadersOffset = $(".main-table-column-headers").offset().top;
        var columnLeftHeadersOffset = $(".main-table-column-headers").offset().left;
        var rowHeadersTopOffset = $(".main-table-row-headers").offset().top;
        var rowHeadersOffset = $(".main-table-row-headers").offset().left;

        $("#s4-workspace").scroll(function () {
            var columnHeaders = $(".main-table-column-headers");
            var rowHeaders = $(".main-table-row-headers");
            var topScroll = $("#s4-workspace").scrollTop();
            var leftScroll = $("#s4-workspace").scrollLeft();

            if (topScroll - columnHeadersOffset >= -65) {
                columnHeaders.addClass("column-fixed");
                columnHeaders.removeClass("column-headers");
                columnHeaders.left = columnLeftHeadersOffset;
                var t = $(".tabstrip-states-params").first().css("left");
                var vi = parseInt(t, 10);
                columnHeaders.css("left", vi - leftScroll - 1 + "px");
            }
            else {
                columnHeaders.removeClass("column-fixed");
                columnHeaders.addClass("column-headers");
                var t = $(".tabstrip-states-params").first().css("left");
                var vi = parseInt(t, 10);
                columnHeaders.css("left", vi - 1 + "px");
            }

            if (leftScroll - rowHeadersOffset >= 0) {
                rowHeaders.addClass("row-fixed");
                rowHeaders.removeClass("row-headers");
                var t = $(".tabstrip-states-params").first().css("top");
                var vi = parseInt(t, 10);
                rowHeaders.css("top", vi - topScroll + 65 + "px");
            }
            else {
                rowHeaders.removeClass("row-fixed");
                rowHeaders.addClass("row-headers");
                rowHeaders.css("top", $(".tabstrip-states-params").first().css("top"));
            }
        });

        $("#params-range-input").trigger("change");

        $("#clscroll-content").scroll(function () {
            $("#clscroll-row-headers").scrollTop($("#clscroll-content").scrollTop());
            $("#clscroll-column-headers").scrollLeft($("#clscroll-content").scrollLeft());
        });

        $("#clscroll-column-headers").scroll(function () {
            $("#clscroll-content").scrollLeft($("#clscroll-column-headers").scrollLeft());
        });

        $("#clscroll-row-headers").scroll(function () {
            $("#clscroll-content").scrollTop($("#clscroll-row-headers").scrollTop());
        });

        var cntfld = $(".tabstrip-fields").find("li").not(".drop-target-field").not(".add-field-li").length;
        var cntstt = $(".tabstrip-states").find("li").not(".drop-target-state").not(".add-state-li").length;
        $(".wizard-app-div").css("width", "4000px").css("height", "3000px");
        $(".tabstrip-states").css("width", (cntstt * 300) + "px");
    };

    $scope.initTypes = function () {

        if ($scope.wizardInitData.types.length > 0) {
            $scope.activeContentType = $scope.wizardInitData.types[0];
        }

        if ($scope.selectedParent == null) {
            $scope.selectedParent = $scope.wizardInitData.parents[0];
        }

        $scope.showDdl();
    };

    $scope.selTypeChanged = function () {
        $scope.selectedType = this.selectedType;
    };

    $scope.selParentChanged = function () {
        $scope.selectedParent = this.selectedParent;
    };

    $scope.loadDictionary = function () {
        $scope.setLocalizedStrings(angular.fromJson($("#dictionatyHidden").val()));
    };

    $scope.getLocalizedString = function (key) {

        if ($scope.localizedStrings.length === 0) {
            $scope.loadDictionary();
        }

        var result = key;
        for (var i = $scope.localizedStrings.length - 1; i >= 0; i--) {
            if ($scope.localizedStrings[i].key == key) {
                result = $scope.localizedStrings[i].localized;
                break;
            }
        }
        return result;
    };

    $scope.setLocalizedStrings = function (value) {
        $scope.localizedStrings = value;
    };

    $scope.getTooltip = function (users, placement) {

        var maxCols = 8;
        var maxOptimalRows = 15;
        var rows = maxOptimalRows;
        var cols = maxCols;
        var htmlContent = "<table class='user-permissions-table'>";

        if (users.length > maxOptimalRows) {
            var xcols = Math.ceil(users.length / maxOptimalRows);
            if (xcols > maxCols) {
                rows = Math.ceil(users.length / maxCols);
                cols = maxCols;
            } else {
                rows = maxOptimalRows;
                cols = xcols;
            }
        } else {
            rows = users.length;
            cols = 1;
        }

        var items = 0;
        for (var i = 0; i < rows; i++) {
            htmlContent = htmlContent + "<tr>";
            for (var j = 0; j < cols; j++) {
                if ((items <= users.length) && ((i + j * rows) < users.length)) {
                    htmlContent = htmlContent + "<td>" + users[i + j * rows].name + "</td>";
                    items++;
                } else {
                    htmlContent = htmlContent + "<td></td>";
                }
            }
            htmlContent = htmlContent + "</tr>";
        }

        htmlContent = htmlContent + "</table>";
        var tooltip = { title: htmlContent, html: true, placement: placement };

        return tooltip;
    };

    $scope.showDdl = function (clicked) {

        $scope.useExistingType = true;

        if (typeof clicked === "undefined") {
            clicked = false;
        }

        if (clicked) {
            if (typeof $scope.previousDescription !== "undefined") {
                $scope.selectedType.description = $scope.previousDescription;
            }
        } else {
            $scope.previousDescription = $scope.selectedType.description;
        }
    };

    $scope.showTxb = function (clicked) {

        $scope.useExistingType = false;

        if (typeof clicked === "undefined") {
            clicked = false;
        }

        if (clicked) {
            $scope.selectedType.description = "";
        }
    };

    $scope.loadWizardInitData = function () {

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetInitData", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ url: window.location.href }) }).then(
            function successCallback(response) {

                $scope.wizardInitData = angular.fromJson(response.data.d);
                $scope.initTypes();

                $scope.wizardTypeData.type = $scope.wizardInitData.types[0];
                /*
                            $scope.refreshTypePermissionsArea();
                
                            $scope.showFetchContentTypeProgressModalDialog();
                            $scope.loadWizardTypeData($scope.wizardTypeData);
                */
                $scope.showSelectTypeModalDialog();
            },
            function errorCallback(response) {
                var error = response;
            });
    };

    $scope.loadWizardTypeData = function (typ) {

        var typeData = angular.toJson(typ);

        $("#fetch-content-type-okbutton").hide();
        $("#fetch-content-type-label").text($scope.getLocalString1Param('WZDContentTypeLoadingProgress', typ.type.name) + " 0 %");

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetTypeDataNoFields", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData }) }).then(
            function successCallback(response) {

                try {
                    var typData = angular.fromJson(response.data.d);
                    $scope.activeContentType = typData.type;

                    var percentage = 20;
                    $("#fetch-content-type-label").text($scope.getLocalString1Param('WZDContentTypeLoadingProgress', typ.type.name) + " " + percentage + " %");

                    // fetch content type fields by 20
                    var percentagestep = Math.ceil(((100 - percentage) / (typData.type.fieldCount / 20)));
                    $scope.getTypeDataPartObject(typData, 0, 20, percentage, percentagestep);

                } catch (error) { }
            },
            function errorCallback(response, status, error) {
                var msg = $scope.getLocalString1Param('WZDTypeLoadingError', typ.type.name)
                $("#fetch-content-type-label").text(msg);
                $("#fetch-content-type-okbutton").show();
            });
    };

    $scope.refreshTypePermissionsArea = function () {

        $("#type-permissions-area").attr("users", angular.toJson($scope.activeContentType.users));
        var element = $("#type-permissions-area");

        var usrs = $(element).attr("users");
        var users = [];
        if (usrs.length > 2) {
            try {
                users = angular.fromJson(usrs);
            } catch (error) { }
        }

        $scope.refreshTypePermissionsDivByValue($(element), users);
    };

    $scope.getTypeDataPartObject = function (typeData, page, count, percentage, percentagestep) {

        var typeDataCopy = angular.copy(typeData);
        typeDataCopy.type.fields = [];
        var typeDataString = angular.toJson(typeDataCopy);

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetTypeDataFieldsPart", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeDataString, page: page, count: count }) }).then(
            function successCallback(response) {

                try {
                    var fieldsPart = angular.fromJson(response.data.d);
                    angular.forEach(fieldsPart.type.fields, function (field) {
                        if (field.stateFieldRelations != null) {
                            angular.forEach(field.stateFieldRelations, function (rel) {
                                rel.originalRequired = angular.copy(rel.required);
                                rel.originalEditable = angular.copy(rel.editable);
                                rel.originalEditableUsers = angular.copy(rel.editors);
                            });
                        }
                        typeData.type.fields.push(field);
                    });
                } catch (error) { }

                percentage = percentage + percentagestep;
                if (percentage > 100) {
                    percentage = 100;
                }
                $("#fetch-content-type-label").text($scope.getLocalString1Param('WZDContentTypeLoadingProgress', typeData.type.name) + " " + percentage + " %");

                // continue field loading until the loaded array id empty
                try {
                    if (fieldsPart.type.fields.length > 0) {
                        $scope.getTypeDataPartObject(typeData, page + 1, count, percentage, percentagestep);
                    } else {
                        $scope.wizardTypeData = angular.copy(typeData);
                        $scope.hideFetchContentTypeProgressModalDialog();
                        $scope.reloadMainTable();
                    }
                } catch (error) { }
            },
            function errorCallback(response, status, error) {
                var r = response;
            });
    };

    $scope.showSelectTypeModalDialog = function () {

        try {
            $scope.selectedType = $scope.wizardTypeData.type;
        } catch (error) {
            $scope.selectedType = { id: '1', name: '', description: '', parent: '', users: [] };
        }

        $scope.createdType = { id: '0', name: '', description: '', parent: '', users: [] };
        $scope.showSelectTypeModal = true;
    };

    $scope.hideSelectTypeModalDialog = function () {
        $scope.showSelectTypeModal = false;
    };

    $scope.showConfirmNewContentTypeModalDialog = function () {
        $scope.showConfirmNewContentTypeModal = true;
    };

    $scope.hideConfirmNewContentTypeModalDialog = function () {
        $scope.showConfirmNewContentTypeModal = false;
    };

    $scope.showFetchContentTypeProgressModalDialog = function () {
        $scope.showFetchContentTypeProgressModal = true;
    };

    $scope.hideFetchContentTypeProgressModalDialog = function () {
        $scope.showFetchContentTypeProgressModal = false;
    };

    $scope.getLocalString = function (key) {
        return $scope.getLocalizedString(key);
    };

    $scope.getLocalString1Param = function (key, param1) {
        var value = $scope.getLocalizedString(key);
        value = value.replace('{0}', param1);
        return value;
    };

    $scope.getLocalString2Param = function (key, param1, param2) {
        var value = $scope.getLocalizedString(key);
        value = value.replace('{0}', param1);
        value = value.replace('{1}', param2);
        return value;
    };

    $scope.getTypePermissionsAreaTooltip = function (users) {
        return $scope.getTooltip(users, "right");
    };

    $scope.selectType = function () {
        if ($scope.useExistingType) {

            $scope.hideSelectTypeModalDialog();

            $scope.activeContentType = $scope.selectedType;
            $scope.wizardTypeData.type = $scope.selectedType;

            $scope.showFetchContentTypeProgressModalDialog();

            $scope.loadWizardTypeData($scope.wizardTypeData);

        } else {
            if ($scope.validate()) {

                $scope.hideSelectTypeModalDialog();

                $scope.createdType.parent = $scope.selectedParent.name;
                $scope.createdType.status = "A";
                $scope.activeContentType = angular.copy($scope.createdType);
                $scope.wizardTypeData.type = angular.copy($scope.createdType);

                $scope.showConfirmNewContentTypeModalDialog();
            }
        }
    };

    $scope.doCreateNewContentType = function () {
        $scope.hideConfirmNewContentTypeModalDialog();

        var typeData = angular.toJson($scope.wizardTypeData);

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/CreateNewContentType", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData, url: window.location.href }) }).then(
            function successCallback(response) {

                try {
                    var newContentType = angular.fromJson(response.data.d);
                    $scope.wizardInitData.types.push($scope.wizardTypeData.type);

                    $scope.showFetchContentTypeProgressModalDialog();
                    $scope.loadWizardTypeData(newContentType);
                } catch (error) { }
            },
            function errorCallback(response) {
            });
    };

    $scope.validate = function () {
        return !($("#selectTypeForm").hasClass("ng-invalid"));
    };

    $scope.showTypePermissionsModalDialog = function () {
        $scope.showTypePermissionsModal = true;
    };

    $scope.hideTypePermissionsModalDialog = function () {
        $scope.showTypePermissionsModal = false;
    };

    $scope.editTypePermissions = function (e, state, field, type) {

        try {
            var element = $(e.target);
            $scope.lastTypeEditedPermissions.element = element;
            $scope.lastTypeEditedPermissions.state = state;
            $scope.lastTypeEditedPermissions.field = field;
            $scope.lastTypeEditedPermissions.type = type;
            if (element.is("div")) {
            } else {
                element = element.closest("div");
                $scope.lastTypeEditedPermissions.element = element;
            }
            var usrs = element.attr("users");
            if (usrs.length > 2) {
                $scope.lastTypeEditedPermissions.radio = "S";
                $scope.lastTypeEditedPermissions.users = angular.fromJson(usrs);
            } else {
                $scope.lastTypeEditedPermissions.radio = "A";
            }
        } catch (error) { }

        $("#peoplePickerDiv").hide();
        $scope.showTypePeoplePicker = false;
        $scope.showTypePermissionsModalDialog();
    };

    $scope.addNewTypePermission = function () {
        $scope.showTypePeoplePicker = true;
        $("#peoplePickerDiv").show();
    };

    $scope.saveNewTypePermission = function () {
        $scope.showTypePeoplePicker = false;
        $("#peoplePickerDiv").hide();
        var peoplePicker = SPClientPeoplePicker.SPClientPeoplePickerDict.peoplePickerDiv_TopSpan;
        var users = peoplePicker.GetAllUserInfo();
        angular.forEach(users, function (u) {
            var usr = { name: u.DisplayText, type: ((u.EntityType == "User") ? "U" : "G") };
            $scope.lastTypeEditedPermissions.users.push(usr);
        });

        var peoplePickerId = 'peoplePickerDiv';
        var resolvedListElementId = peoplePicker.ResolvedListElementId;
        angular.forEach(users, function (u) {
            var elementToRemove = '';
            $('#' + resolvedListElementId).children().each(function (index, element) {
                if (element.id.startsWith(peoplePickerId + '_TopSpan_' + u.Key + '_ProcessedUser')) {
                    elementToRemove = element;
                    return false;
                }
            });
            peoplePicker.DeleteProcessedUser(elementToRemove);
        });
    };

    $scope.removeExistingTypePermission = function (user) {
        var currentUsers = $scope.lastTypeEditedPermissions.users;
        $scope.lastTypeEditedPermissions.users = [];
        angular.forEach(currentUsers, function (u) {
            if (u.name != user.name) {
                $scope.lastTypeEditedPermissions.users.push(u);
            }
        });
    };

    $scope.refreshTypePermissionsDivByValue = function (element, usersVal) {
        var usersNum = 0;
        var groupsNum = 0;
        var users = [];
        var tt = { title: '' };
        if (usersVal.length > 0) {
            try {
                users = angular.fromJson(usersVal);
                angular.forEach(users, function (user) {
                    if (user.type == "G") {
                        groupsNum++;
                    } else {
                        usersNum++;
                    }
                });
            } catch (error) { }
        }
        tt = $scope.getTypePermissionsAreaTooltip(users);
        $(element).closest("div.user-permissions-div").attr('data-original-title', tt.title);
        $(element).closest("div.user-permissions-div").tooltip((users.length > 0) ? tt : 'destroy');
        var divElement = $(element).closest("div.user-permissions-div");
        divElement.empty();
        if ((usersNum == 0) && (groupsNum == 0)) {
            var usr = $scope.getLocalString('WZDUsersEverybody');
            divElement.append("<label class='user-permissions-label'>" + usr + "</label>");
        } else {
            divElement.append(tt.title);
        }
    };

    $scope.saveTypePermissions = function () {
        if ($scope.validatePermissions()) {
            $scope.hideTypePermissionsModalDialog();

            var usersValue = [];
            if ($scope.lastTypeEditedPermissions.radio == "S") { usersValue = $scope.lastTypeEditedPermissions.users; }

            $scope.wizardTypeData.type.users = usersValue;

            if ($scope.workOnline) {
                var simpleType = angular.copy($scope.wizardTypeData);
                simpleType.type.fields = [];
                simpleType.type.states = [];
                $scope.sendPermissionToServer(simpleType, '', '', 'T');
            }

            $($scope.lastTypeEditedPermissions.element).attr('users', angular.toJson(usersValue));
            $scope.refreshTypePermissionsDivByValue($($scope.lastTypeEditedPermissions.element), usersValue);
        }
        $scope.lastTypeEditedPermissions = { users: [], radio: 'A', element: '', state: '', field: '', type: '' };
    };

    $scope.sendTypePermissionToServer = function (typ, stav, pole, permissionsType) {

        if ($scope.workOnline) {
            var typeData = angular.toJson(typ);
            var stateData = angular.toJson(stav);
            var fieldData = angular.toJson(pole);

            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/SetPermissions", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData, jsonState: stateData, jsonField: fieldData, permissionsType: permissionsType, url: window.location.href }) }).then(
                function successCallback(response) {

                    var permissions = angular.fromJson(response.data.d);
                },
                function errorCallback(response) {
                });
        }
    };

    $scope.validateTypePermissions = function () {
        return !($("#statePermissionsForm").hasClass("ng-invalid"));
    };

    ////////////////////////////////////////////////
    /// XmlFiles ///////////////////////////////////
    ////////////////////////////////////////////////

    $scope.publish = function (clicked) {
        $scope.showPublishContentTypeModalDialog();
    };

    $scope.showPublishContentTypeProgressModalDialog = function () {
        $scope.showPublishContentTypeProgressModal = true;
    };

    $scope.hidePublishContentTypeProgressModalDialog = function () {
        $scope.showPublishContentTypeProgressModal = false;
    };

    $scope.saveDraft = function (clicked) {

        var ie = navigator.userAgent.match(/MSIE\s([\d.]+)/),
            ie11 = navigator.userAgent.match(/Trident\/7.0/) && navigator.userAgent.match(/rv:11/),
            ieEDGE = navigator.userAgent.match(/Edge/g),
            ieVer = (ie ? ie[1] : (ie11 ? 11 : (ieEDGE ? 12 : -1)));

        if (ie && ieVer < 10) {
            return;
        }

        var textFileAsBlob = new Blob([angular.toJson($scope.wizardTypeData, true)], {
            type: 'text/plain'
        });

        if (ieVer > -1) {
            window.navigator.msSaveBlob(textFileAsBlob, $scope.xmlFileName);

        } else {
            var downloadLink = document.createElement("a");
            downloadLink.download = $scope.xmlFileName;
            downloadLink.href = window.URL.createObjectURL(textFileAsBlob);
            downloadLink.onclick = function (e) { document.body.removeChild(e.target); };
            downloadLink.style.display = "none";
            document.body.appendChild(downloadLink);
            downloadLink.click();
        }
    };

    $scope.loadDraft = function (clicked) {
        $("#load-draft-file-input").trigger('click');
    };

    $scope.reloadWizard = function (data) {
        $timeout(function () {
            $scope.draftData = angular.fromJson(data);
            $scope.showReplaceTypeByDraftModalDialog();
        }, 50);
    };
    /*    
        $scope.readDraft = function (event) {
            
            var element = event.target;
            var reader = new FileReader();
            reader.onload = function (e) {
                $scope.reloadWizard(e.target.result);
                $("#load-draft-file-input").val("");
            };
            reader.onerror = function (e) {
                $("#load-draft-file-input").val("");
            };
            reader.readAsText(element.files[0]);
        };
    */
    $scope.doReplaceTypeByDraft = function () {
        $scope.wizardTypeData = angular.copy($scope.draftData);
        $scope.hideReplaceTypeByDraftModalDialog();
    };

    $scope.showPublishContentTypeModalDialog = function () {
        $scope.showPublishContentTypeModal = true;
    };

    $scope.hidePublishContentTypeModalDialog = function () {
        $scope.showPublishContentTypeModal = false;
    };

    $scope.showReplaceTypeByDraftModalDialog = function () {
        $scope.showReplaceTypeByDraftModal = true;
    };

    $scope.hideReplaceTypeByDraftModalDialog = function () {
        $scope.showReplaceTypeByDraftModal = false;
    };

    $scope.doPublishContentType = function () {

        $scope.hidePublishContentTypeModalDialog();
        $scope.showPublishContentTypeProgressModalDialog();

        var typeWithoutFields = angular.copy($scope.wizardTypeData);
        typeWithoutFields.type.fields = [];
        var typeDataWithoutFields = angular.toJson(typeWithoutFields);

        var percentage = 0;
        var percentagestep = Math.ceil(((100 - percentage) / ($scope.wizardTypeData.type.fields.length / 10)));

        var labels = $("#publish-content-type-label").length;
        $("#publish-content-type-label").text($scope.getLocalString1Param('WZDTypeUpdatingProgress', typeWithoutFields.type.name) + " " + percentage + " %");
        $("#publish-content-type-okbutton").hide();
        $("#publish-content-type-image").show();

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/PublishWithoutFields", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeDataWithoutFields, url: window.location.href }) }).then(
            function successCallback(response) {
                var msg = "";
                if (response.data.d == "OK") {

                    percentage = 20;
                    $("#publish-content-type-label").text($scope.getLocalString1Param('WZDTypeUpdatingProgress', typeWithoutFields.type.name) + " " + percentage + " %");

                    $scope.doPublishContentTypeFields($scope.wizardTypeData, 0, 10, percentage, percentagestep);
                } else {
                    msg = $scope.getLocalString1Param('WZDTypeUpdatingError', typeWithoutFields.type.name);
                    $("#publish-content-type-label").text(msg);
                    $("#publish-content-type-okbutton").show();
                }
            },
            function errorCallback(response) {
                msg = $scope.getLocalString1Param('WZDTypeUpdatingError', typeWithoutFields.type.name);
                $("#publish-content-type-label").text(msg);
                $("#publish-content-type-okbutton").show();
            });
    };

    $scope.doPublishContentTypeFields = function (ctyp, page, count, percentage, percentagestep) {

        var isLastPart = false;
        var ctypcopy = angular.copy(ctyp);
        ctypcopy.type.fields = [];
        var fmin = (page * count);
        var fmax = ((page + 1) * count);
        if (fmax > ctyp.type.fields.length) {
            fmax = ctyp.type.fields.length;
            isLastPart = true;
        }
        for (var i = fmin; i < fmax; i++) {
            ctypcopy.type.fields.push(ctyp.type.fields[i]);
        }

        var typeDataWithFields = angular.toJson(ctypcopy);

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/PublishTypeFieldPart", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeDataWithFields, url: window.location.href }) }).then(
            function successCallback(response) {

                percentage = percentage + percentagestep;
                if (percentage > 100) {
                    percentage = 100;
                }
                $("#publish-content-type-label").text($scope.getLocalString1Param('WZDTypeUpdatingProgress', ctypcopy.type.name) + " " + percentage + " %");

                // continue field loading until the loaded array id empty
                if (isLastPart) {
                    $("#publish-content-type-image").hide();
                    $("#publish-content-type-label").text($scope.getLocalString1Param('WZDTypeUpdatingSuccess', ctypcopy.type.name));
                    $("#publish-content-type-okbutton").show();
                } else {
                    $scope.doPublishContentTypeFields(ctyp, page + 1, count, percentage, percentagestep);
                }
            },
            function errorCallback(response, status, error) {
                $("#publish-content-type-label").text($scope.getLocalString1Param('WZDTypeFieldsUpdatingError', ctypcopy.type.name));
                $("#publish-content-type-okbutton").show();
            });
    };

    /////////////////////////////////////////////////
    /////// Main ////////////////////////////////////
    /////////////////////////////////////////////////

    $scope.initDrags = function () {

        $('.tabstrip-states li.state-li').draggable({
            axis: 'x',
            opacity: 0.7,
            helper: 'clone',
            start: function () {
                $("li.drop-target-state").addClass('highlight-state');
                $(this).prev().removeClass('highlight-state');
                $(this).next().removeClass('highlight-state');
                $scope.elementDragged = this;
            },
            drag: function () {
            },
            stop: function () {
                $('li.drop-target-state').removeClass('highlight-state');
                $scope.elementDragged = null;
            }
        });
        $('.tabstrip-states li.drop-target-state').droppable({
            over: function (event, ui) {
                event.target.classList.add('selected-state');
            },
            out: function (event, ui) {
                event.target.classList.remove('selected-state');
            },
            drop: function (event, ui) {
                try {
                    $(this).removeClass('highlight-state');
                    $scope.changeStatePosition($scope.elementDragged);
                    $(this).removeClass('selected-state');
                    $scope.elementDragged = null;

                    $scope.$apply();

                } catch (error) { }
            }
        });
        if ($scope.selectedOrder.key == 'order') {
            $('.tabstrip-fields li.field-li').draggable({
                axis: 'y',
                opacity: 0.7,
                helper: 'clone',
                start: function () {
                    $("li.drop-target-field").addClass('highlight-field');
                    $(this).prev().removeClass('highlight-field');
                    $(this).next().removeClass('highlight-field');
                    $scope.elementDragged = this;
                },
                drag: function () {
                },
                stop: function () {
                    $('li.drop-target-field').removeClass('highlight-field');
                    $scope.elementDragged = null;
                }
            });
            $('.tabstrip-fields li.drop-target-field').droppable({
                over: function (event, ui) {
                    event.target.classList.add('selected-field');
                },
                out: function (event, ui) {
                    event.target.classList.remove('selected-field');
                },
                drop: function (event, ui) {
                    try {
                        $(this).removeClass('highlight-field');
                        $scope.changeFieldPosition($scope.elementDragged);
                        $(this).removeClass('selected-field');
                        $scope.elementDragged = null;

                        $scope.$apply();

                    } catch (error) { }
                }
            });
        }
    };

    $scope.changeStatePosition = function (dragged) {

        try {
            var lisSelected = $("#state-elements > li.selected-state")[0];
            var draggedStateName = $(dragged).find("label.state-name-label").html();
            var draggedDataIndex = $scope.getStateIndexByName(draggedStateName);
            var selectedState = $(lisSelected).next(".state-li");
            var selectedDataIndex = -1;
            if (selectedState.length == 0) {
                selectedDataIndex = $scope.getLastUsedStateIndex() + 1;
            } else {
                var selectedStateName = $(selectedState[0]).find("label.state-name-label").html();
                selectedDataIndex = $scope.getStateIndexByName(selectedStateName);
            }

            if (selectedDataIndex < draggedDataIndex) {
                var draggedState = $scope.wizardTypeData.type.states[draggedDataIndex];
                for (var p = (draggedDataIndex - 1); p >= selectedDataIndex; p--) {
                    $scope.wizardTypeData.type.states[p + 1] = $scope.wizardTypeData.type.states[p];
                }
                $scope.wizardTypeData.type.states[selectedDataIndex] = draggedState;
            } else {
                var draggedState = $scope.wizardTypeData.type.states[draggedDataIndex];
                for (var p = (draggedDataIndex + 1); p < selectedDataIndex; p++) {
                    $scope.wizardTypeData.type.states[p - 1] = $scope.wizardTypeData.type.states[p];
                }
                $scope.wizardTypeData.type.states[selectedDataIndex - 1] = draggedState;
            }
        } catch (error) { }
    };

    $scope.changeFieldPosition = function (dragged) {

        try {
            var lisSelected = $("#field-elements > li.selected-field")[0];
            var draggedFieldName = $(dragged).find("label.field-name-label").html();
            var draggedDataIndex = $scope.getFieldIndexByName(draggedFieldName);
            var selectedField = $(lisSelected).next(".field-li");
            var selectedFieldName = $(selectedField).find("label.field-name-label").html();
            if (draggedFieldName == selectedFieldName) {
                selectedField = '';
            }
            var selectedDataIndex = -1;
            if (selectedField.length == 0) {
                selectedDataIndex = $scope.getLastUsedFieldIndex() + 1;
            } else {
                var selectedFieldName = $(selectedField[0]).find("label.field-name-label").html();
                selectedDataIndex = $scope.getFieldIndexByName(selectedFieldName);
            }

            if (selectedDataIndex < draggedDataIndex) {

                var selectedFieldOrder = $scope.wizardTypeData.type.fields[selectedDataIndex].order;
                for (var p = selectedDataIndex; p < draggedDataIndex; p++) {
                    $scope.wizardTypeData.type.fields[p].order = $scope.wizardTypeData.type.fields[p + 1].order;
                }
                $scope.wizardTypeData.type.fields[draggedDataIndex].order = selectedFieldOrder;

                var draggedField = $scope.wizardTypeData.type.fields[draggedDataIndex];
                for (var p = draggedDataIndex; p > selectedDataIndex; p--) {
                    $scope.wizardTypeData.type.fields[p] = $scope.wizardTypeData.type.fields[p - 1];
                }
                $scope.wizardTypeData.type.fields[selectedDataIndex] = draggedField;

            } else {

                var preselectedFieldOrder = $scope.wizardTypeData.type.fields[selectedDataIndex - 1].order;
                for (var p = (draggedDataIndex + 1); p < selectedDataIndex; p++) {
                    $scope.wizardTypeData.type.fields[p].order = $scope.wizardTypeData.type.fields[p - 1].order;
                }
                $scope.wizardTypeData.type.fields[draggedDataIndex].order = preselectedFieldOrder;

                var draggedField = $scope.wizardTypeData.type.fields[draggedDataIndex];
                for (var p = (draggedDataIndex + 1); p < selectedDataIndex; p++) {
                    $scope.wizardTypeData.type.fields[p - 1] = $scope.wizardTypeData.type.fields[p];
                }
                $scope.wizardTypeData.type.fields[selectedDataIndex - 1] = draggedField;
            }

        } catch (error) {
            var message = error;
        }
    };

    $scope.selOrderChanged = function (ord) {
        if ($scope.selectedOrder.key == 'order') {
            $scope.initDrags();
        }
    };

    $scope.isUsedState = function (state) {
        return (!((state.status == "U") || (state.status == "D")));
    };

    $scope.isUsedField = function (field) {
        return (!((field.status == "U") || (field.status == "D")));
    };

    $scope.isUnusedField = function (field) {
        return ((field.status == "U") || (field.status == "D"));
    };

    $scope.showStatePermissionsModalDialog = function () {
        $scope.showStatePermissionsModal = true;
    };

    $scope.hideStatePermissionsModalDialog = function () {
        $scope.showStatePermissionsModal = false;
    };

    $scope.setDefaultState = function (state) {
        angular.forEach($scope.wizardTypeData.type.states, function (st) {
            st.typeStateRelation.default = (st.state == state.state);
        });
    };

    $scope.getFieldStateEditors = function (field, state) {
        var result = "";

        try {
            for (var fl = 0; fl < $scope.wizardTypeData.type.fields.length; fl++) {
                var fld = $scope.wizardTypeData.type.fields[fl];
                if (fld.internalName === field.internalName) {
                    for (var st = 0; st < fld.stateFieldRelations.length; st++) {
                        var stt = fld.stateFieldRelations[st];
                        if (stt.state === state.state) {
                            result = ((stt.editable) ? stt.editors : [{ type: 'N' }]);
                            break;
                        }
                    }
                    break;
                }
            }
        } catch (error) { result = [{ type: 'N' }]; }

        return result;
    };

    $scope.getTypePermissionsAreaTooltip = function (users) {
        return $scope.getTooltip(users, "top");
    };

    $scope.reloadMainTable = function () {
        $scope.rereadUnusedFields();

        $timeout(function () {
            $scope.refreshMainTable();

            var permissionsDivs = $(".user-permissions-div");
            angular.forEach(permissionsDivs, function (permissionsDiv) {

                var element = $(permissionsDiv);

                var usrs = $(element).attr("users");
                var users = [];
                if (usrs.length > 2) {
                    try {
                        users = angular.fromJson(usrs);
                    } catch (error) { }
                }

                $scope.refreshPermissionsDivByValue($(element), users);
            });

            var fieldPermissionsDivs = $(".user-field-permissions-div");
            angular.forEach(fieldPermissionsDivs, function (fieldPermissionsDiv) {

                var element = $(fieldPermissionsDiv);

                var usrs = $(element).attr("users");
                var users = [];
                if (usrs.length > 2) {
                    try {
                        users = angular.fromJson(usrs);
                    } catch (error) { }
                }

                $scope.refreshPermissionsDivByValue($(element), users);
            });

        }, 100);
    };

    $scope.refreshMainTable = function () {

        var cellSize = $scope.cellSize;

        $(".tooltip-inner").css("min-width", (cellSize * 0.9) + "px");
        $(".tabstrip-states").find("div.state-label-div").css("width", cellSize + "px");

        var cntstt = 20;
        $(".tabstrip-states").find("li").find("> div.state-params-div").css("overflow", "hidden").css("width", cellSize + "px");
        $(".tabstrip-states").css("width", (150 + (cntstt * cellSize)) + "px");

        $(".tabstrip-states-params").find("li").find("> div.state-params-div").css("overflow", "hidden").css("width", cellSize + "px").css("padding-bottom", "11px");
        $(".tabstrip-states-params").css("width", (150 + (cntstt * cellSize)) + "px");

        $(".tabstrip-states-fields").find("div.field-flags-div").css("width", "100%");

        $scope.refresh();
    };

    $scope.editPermissions = function (e, state, field, type) {

        var element = $(e.target);
        $scope.lastEditedPermissions.element = element;
        $scope.lastEditedPermissions.state = state;
        $scope.lastEditedPermissions.field = field;
        $scope.lastEditedPermissions.type = type;
        if (element.is("div")) {
        } else {
            element = element.closest("div");
            $scope.lastEditedPermissions.element = element;
        }

        $("#peoplePickerStateDiv").hide();
        $scope.showPeoplePicker = false;

        if (field != '') {

            if ($scope.workOnline) {
                var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
                $http({ method: "POST", url: urlBase + "Wizard.aspx/GetFieldEdit", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: state.state, field: field.internalName, url: window.location.href }) }).then(
                    function successCallback(response) {

                        var fieldEditData = angular.fromJson(response.data.d);
                        if (fieldEditData.stateFieldRelations[0].editable) {
                            if (fieldEditData.stateFieldRelations[0].editors.length > 0) {
                                $scope.lastEditedPermissions.radio = "S";
                                $scope.lastEditedPermissions.users = fieldEditData.stateFieldRelations[0].editors;
                            } else {
                                $scope.lastEditedPermissions.radio = "A";
                                $scope.lastEditedPermissions.users = [];
                            }
                        } else {
                            $scope.lastEditedPermissions.radio = "N";
                            $scope.lastEditedPermissions.users = [];
                        }

                        $scope.showStatePermissionsModalDialog();
                    },
                    function errorCallback(response) {
                        var error = response;
                    });
            } else {
                var relationObj = null;
                for (var i = field.stateFieldRelations.length - 1; i >= 0; i--) {
                    if (field.stateFieldRelations[i].state == state.state) {
                        relationObj = field.stateFieldRelations[i];
                        break;
                    }
                }
                if (relationObj.editable) {
                    if (relationObj.editors.length > 0) {
                        $scope.lastEditedPermissions.radio = "S";
                        $scope.lastEditedPermissions.users = relationObj.editors;
                    } else {
                        $scope.lastEditedPermissions.radio = "A";
                        $scope.lastEditedPermissions.users = [];
                    }
                } else {
                    $scope.lastEditedPermissions.radio = "N";
                    $scope.lastEditedPermissions.users = [];
                }

                $scope.showStatePermissionsModalDialog();
            }
        } else {
            if ((type == "U")) {
                if (state.typeStateRelation.users.length > 0) {
                    $scope.lastEditedPermissions.radio = "S";
                    $scope.lastEditedPermissions.users = state.typeStateRelation.users;
                } else {
                    $scope.lastEditedPermissions.radio = "A";
                    $scope.lastEditedPermissions.users = [];
                }

                $scope.showStatePermissionsModalDialog();
            }
            if ((type == "E") || (type == "R")) {
                $scope.showUpdateStatePermissionsItemModal(state);
            }
        }
    };
    /*
        $scope.showUpdateStatePermissionsItemModal = function (state) {
    
            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/GetStatePermissionsId", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: state.state, url: window.location.href }) }).then(
            function successCallback(response) {
    
                var idStr = angular.fromJson(response.data.d);
                var idNum = parseInt(idStr, 10);
                if (idNum > -1) {
                    var listBase = window.location.href.substring(0, window.location.href.lastIndexOf('_layouts'));
                    dokoniCASECore.OpenInDialogWithCallback(800, 450, false, true, listBase + "/Lists/ConfigurationPermissions/EditForm.aspx?mobile=0&ID=" + idStr, $scope.stateDialogCallback);
                }
            },
            function errorCallback(response) {
                var error = response;
            });
        };
    */
    $scope.showUpdateStatePermissionsItemModal = function (state) {

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetStatePermissionsId", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: state.state, url: window.location.href }) }).then(
            function successCallback(response) {

                var idStr = angular.fromJson(response.data.d);
                var idNum = parseInt(idStr, 10);
                if (idNum > -1) {
                    var listBase = window.location.href.substring(0, window.location.href.lastIndexOf('_layouts'));
                    var options = {
                        url: listBase + "/Lists/ConfigurationPermissions/EditForm.aspx?mobile=0&ID=" + idStr,
                        width: 800,
                        height: 450,
                        dialogReturnValueCallback: $scope.stateDialogCallback,
                        title: $scope.getLocalString('WZDAdditionalStatePermissions'),
                        showClose: true
                    };

                    SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                }
            },
            function errorCallback(response) {
                var error = response;
            });
    };

    $scope.addNewPermission = function () {
        $scope.showPeoplePicker = true;
        $("#peoplePickerStateDiv").show();
    };

    $scope.saveNewPermission = function () {
        $scope.showPeoplePicker = false;
        $("#peoplePickerStateDiv").hide();
        var statePeoplePicker = SPClientPeoplePicker.SPClientPeoplePickerDict.peoplePickerStateDiv_TopSpan;
        var users = statePeoplePicker.GetAllUserInfo();
        angular.forEach(users, function (u) {
            var usr = { name: u.DisplayText, type: ((u.EntityType == "User") ? "U" : "G") };
            $scope.lastEditedPermissions.users.push(usr);
        });

        var peoplePickerId = 'peoplePickerStateDiv';
        var resolvedListElementId = statePeoplePicker.ResolvedListElementId;
        angular.forEach(users, function (u) {
            var elementToRemove = '';
            $('#' + resolvedListElementId).children().each(function (index, element) {
                if (element.id.startsWith(peoplePickerId + '_TopSpan_' + u.Key + '_ProcessedUser')) {
                    elementToRemove = element;
                    return false;
                }
            });
            statePeoplePicker.DeleteProcessedUser(elementToRemove);
        });
    };

    $scope.removeExistingPermission = function (user) {
        var currentUsers = $scope.lastEditedPermissions.users;
        $scope.lastEditedPermissions.users = [];
        angular.forEach(currentUsers, function (u) {
            if (u.name != user.name) {
                $scope.lastEditedPermissions.users.push(u);
            }
        });
    };

    $scope.refreshPermissionsDivByValue = function (element, usersValue) {
        var editable = true;
        var usersNum = 0;
        var users = [];
        var groupsNum = 0;
        var tt = { title: '' };
        var isStateElement = (($scope.lastEditedPermissions.field == null) || ($scope.lastEditedPermissions.field == ''));
        var elementPermissionSection = element.attr("permission-section");
        var isSpecialPermissionElement = (isStateElement && ((elementPermissionSection === 'SE') || (elementPermissionSection === 'SR')));
        var closestDiv = (isStateElement ? $(element).closest("div.user-permissions-div") : $(element).closest("div.user-field-permissions-div"));
        if (usersValue.length > 0) {
            try {
                users = usersValue;
                if (users[0].type == "N") {
                    editable = false;
                } else {
                    angular.forEach(users, function (user) {
                        if (user.type == "G") {
                            groupsNum++;
                        } else {
                            usersNum++;
                        }
                    });
                }
            } catch (error) { }
        }

        tt = $scope.getTypePermissionsAreaTooltip(users);
        $(closestDiv).empty();
        if ((usersNum == 0) && (groupsNum == 0)) {
            if (isStateElement) {
                if (isSpecialPermissionElement) {
                    $(closestDiv).append("<label class='user-permissions-label'>" + $scope.getLocalString('WZDUsersNobody') + "</label>");
                } else {
                    $(closestDiv).append("<label class='user-permissions-label'>" + (editable ? $scope.getLocalString('WZDUsersEverybody') : $scope.getLocalString('WZDUsersNobody')) + "</label>");
                }
            } else {
                $(closestDiv).append("<label class='user-field-permissions-label'>" + (editable ? $scope.getLocalString('WZDUsersEverybody') : $scope.getLocalString('WZDUsersNobody')) + "</label>");
            }
            $(closestDiv).tooltip('destroy');
        } else {
            $(closestDiv).append(tt.title);
            $(closestDiv).tooltip(tt);
            $(closestDiv).attr('data-original-title', tt.title);
        }
    };

    $scope.refreshPermissionsDivByValue2 = function (element, usersValue) {
        var editable = true;
        var usersNum = 0;
        var users = [];
        var groupsNum = 0;
        var tt = { title: '' };
        var closestDiv = $(element);
        if (usersValue.length > 0) {
            try {
                users = usersValue;
                if (users[0].type == "N") {
                    editable = false;
                } else {
                    angular.forEach(users, function (user) {
                        if (user.type == "G") {
                            groupsNum++;
                        } else {
                            usersNum++;
                        }
                    });
                }
            } catch (error) { }
        }
        tt = $scope.getTypePermissionsAreaTooltip(users);
        $(closestDiv).empty();
        if ((usersNum == 0) && (groupsNum == 0)) {
            if (editable) {
                $(closestDiv).append("<label class='user-field-permissions-label'>" + $scope.getLocalString('WZDUsersEverybody') + "</label>");
            } else {
                $(closestDiv).append("<label class='user-field-permissions-label'>" + $scope.getLocalString('WZDUsersNobody') + "</label>");
            }
        } else {
            $(closestDiv).append(tt.title);
            $(closestDiv).tooltip(tt);
            $(closestDiv).attr('data-original-title', tt.title);
        }
    };

    $scope.savePermissions = function () {

        if ($scope.validatePermissions()) {
            $scope.hideStatePermissionsModalDialog();

            var usersValue = [];
            var editable = true;
            if ($scope.lastEditedPermissions.radio == "N") { usersValue = [{ type: 'N' }]; editable = false; }
            if ($scope.lastEditedPermissions.radio == "S") { usersValue = $scope.lastEditedPermissions.users; editable = true; }

            var fieldObj = null;
            var relationObj = null;
            if ($scope.lastEditedPermissions.state.length == 0) {
                $scope.wizardTypeData.type.users = usersValue;
            } else {
                var stateObj = null;
                for (var i = $scope.wizardTypeData.type.states.length - 1; i >= 0; i--) {
                    if ($scope.wizardTypeData.type.states[i].state == $scope.lastEditedPermissions.state.state) {
                        stateObj = $scope.wizardTypeData.type.states[i];
                        break;
                    }
                }
                if ($scope.lastEditedPermissions.field.length == 0) {
                    if ($scope.lastEditedPermissions.type == 'U') {
                        stateObj.typeStateRelation.users = usersValue;

                        var simpleType = angular.copy($scope.wizardTypeData);
                        simpleType.type.fields = [];
                        simpleType.type.states = [];
                        $scope.sendPermissionToServer(simpleType, angular.copy(stateObj), '', 'U');
                    }
                    if ($scope.lastEditedPermissions.type == 'E') {
                        stateObj.typeStateRelation.editors = usersValue;
                    }
                    if ($scope.lastEditedPermissions.type == 'R') {
                        stateObj.typeStateRelation.readers = usersValue;
                    }
                } else {
                    for (var i = $scope.wizardTypeData.type.fields.length - 1; i >= 0; i--) {
                        if ($scope.wizardTypeData.type.fields[i].internalName == $scope.lastEditedPermissions.field.internalName) {
                            fieldObj = $scope.wizardTypeData.type.fields[i];
                            break;
                        }
                    }
                    for (var i = fieldObj.stateFieldRelations.length - 1; i >= 0; i--) {
                        if (fieldObj.stateFieldRelations[i].state == stateObj.state) {
                            relationObj = fieldObj.stateFieldRelations[i];
                            break;
                        }
                    }
                    relationObj.editors = usersValue;
                    relationObj.editable = editable;
                }
            }
            $($scope.lastEditedPermissions.element).attr('users', angular.toJson(usersValue));
            $scope.refreshPermissionsDivByValue($($scope.lastEditedPermissions.element), usersValue);

            if ($scope.workOnline) {

                var active = true;
                var editors = usersValue;
                if ($scope.lastEditedPermissions.radio == "A") { editors = []; }
                if ($scope.lastEditedPermissions.radio == "N") { editors = []; active = false; }

                var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
                $http({ method: "POST", url: urlBase + "Wizard.aspx/SetFieldEdit", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: relationObj.state, field: fieldObj.internalName, active: active, users: editors, url: window.location.href }) }).then(
                    function successCallback(response) {
                        var fieldEditData = angular.fromJson(response.data.d);;
                    },
                    function errorCallback(response) {
                    });
            }
        }
        $scope.lastEditedPermissions = { users: [], radio: 'A', element: '', state: '', field: '', type: '' };
    };

    $scope.validatePermissions = function () {
        return !($("#statePermissionsForm").hasClass("ng-invalid"));
    };

    $scope.selectText = function (ev) {
        var element = $(ev.target);
        var doc = document;
        var text = element[0];
        if (doc.body.createTextRange) {
            var range = doc.body.createTextRange();
            range.moveToElementText(text);
            range.select();
        } else {
            var selection = window.getSelection();
            var range = doc.createRange();
            range.selectNodeContents(text);
            selection.removeAllRanges();
            selection.addRange(range);
        }
    };

    $scope.refresh = function () {
        $timeout(function () {
            $scope.initDrags();
        }, 500);
    };

    /////////////////////////////////////
    // States
    /////////////////////////////////////

    $scope.sendStateToServer = function (stateObject) {

        if ($scope.workOnline) {
            var stateData = angular.toJson(stateObject);

            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/SetState", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, stateObject: stateData, url: window.location.href }) }).then(
                function successCallback(response) {

                    var idStr = angular.fromJson(response.data.d);
                    var idNum = parseInt(idStr, 10);
                },
                function errorCallback(response) {
                    var error = response;
                });
        }
    };

    $scope.stateDialogCallback = function (dialogResult, data) {
        $scope.reloadTypeAndStates();
    }

    $scope.sendPermissionToServer = function (typ, stav, pole, permissionsType) {

        if ($scope.workOnline) {
            var typeData = angular.toJson(typ);
            var stateData = angular.toJson(stav);
            var fieldData = angular.toJson(pole);

            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/SetPermissions", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData, jsonState: stateData, jsonField: fieldData, permissionsType: permissionsType, url: window.location.href }) }).then(
                function successCallback(response) {
                },
                function errorCallback(response) {
                });
        }
    };

    $scope.reloadTypeAndStates = function () {

        var typ = angular.copy($scope.wizardTypeData);
        var oldfields = angular.copy(typ.type.fields);
        typ.type.fields = [];
        var typeData = angular.toJson(typ);

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetTypeDataNoFields", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData }) }).then(
            function successCallback(response) {

                $scope.wizardTypeData = angular.fromJson(response.data.d);
                $scope.wizardTypeData.type.fields = oldfields;
            },
            function errorCallback(response, status, error) {
            });
    };

    $scope.showStateDdl = function () {
        $scope.useExistingState = true;
    };

    $scope.showStateTxb = function () {
        $scope.useExistingState = false;
    };

    $scope.selStateAdded = function (state) {
        $scope.addedState = angular.copy(state);
    };

    $scope.showAddStateDialog = function () {
        $scope.rereadUnusedStates();
        $scope.addedState = $scope.unusedStates[0];

        $scope.showAddStateModalDialog();
    };

    $scope.showAddStateModalDialog = function () {
        $scope.showAddStateModal = true;
    };

    $scope.hideAddStateModalDialog = function () {
        $scope.showAddStateModal = false;
    };

    $scope.rereadUnusedStates = function () {
        $scope.unusedStates = [];
        angular.forEach($scope.wizardTypeData.type.states, function (stt) {
            if ((stt.status == 'U') || (stt.status == 'D')) {
                $scope.unusedStates.push(angular.copy(stt));
            }
        });
    };

    $scope.showEditStateModalDialog = function () {
        $scope.showEditStateModal = true;
    };

    $scope.hideEditStateModalDialog = function () {
        $scope.showEditStateModal = false;
    };

    $scope.showDeleteStateModalDialog = function () {
        $scope.showDeleteStateModal = true;
    };

    $scope.hideDeleteStateModalDialog = function () {
        $scope.showDeleteStateModal = false;
    };

    $scope.askChangeStateFinalFlag = function (state) {
        $scope.stateChangedFinalFlag = state;
        $scope.showChangeStateFinalFlagModalDialog();
    };

    $scope.showChangeStateFinalFlagModalDialog = function () {
        $scope.showChangeStateFinalFlagModal = true;
    };

    $scope.hideChangeStateFinalFlagModalDialog = function () {
        $scope.showChangeStateFinalFlagModal = false;
    };

    $scope.addState = function () {

        if ($scope.useExistingState) {

            var index = -1;
            for (var i = 0; i < $scope.wizardTypeData.type.states.length; i++) {
                if ($scope.wizardTypeData.type.states[i].state == $scope.addedState.state) {

                    angular.forEach($scope.wizardTypeData.type.fields, function (fld) {
                        var relation = { state: $scope.wizardTypeData.type.states[i].state, required: false, editable: true, editors: [], canChangeRequired: true, canChangeEditable: true };
                        if (fld.stateFieldRelations.length > 0) {
                            relation.canChangeRequired = fld.stateFieldRelations[0].canChangeRequired;
                            relation.canChangeEditable = fld.stateFieldRelations[0].canChangeEditable;
                        }
                        fld.stateFieldRelations.push(relation);
                    });

                    $scope.wizardTypeData.type.states[i].status = "A";
                    index = i;

                    break;
                }
            }

            $scope.hideAddStateModalDialog();

            var sirka = $(".tabstrip-states").css("width");
            if (sirka.substr(-2) === "px") {
                sirka = sirka.substr(0, sirka.length - 2);
                var cellSize = $scope.cellSize;
                $(".tabstrip-states").css("width", parseInt(sirka) + parseInt(cellSize) + "px");
            }

            $scope.refresh();

            $scope.sendStateToServer($scope.wizardTypeData.type.states[index]);

        } else {
            if ($scope.validateState()) {

                angular.forEach($scope.wizardTypeData.type.fields, function (fld) {
                    var relation = { state: $scope.createdState.state, required: false, editable: true, editors: [], canChangeRequired: true, canChangeEditable: true };
                    if (fld.stateFieldRelations.length > 0) {
                        relation.canChangeRequired = fld.stateFieldRelations[0].canChangeRequired;
                        relation.canChangeEditable = fld.stateFieldRelations[0].canChangeEditable;
                    }
                    fld.stateFieldRelations.push(relation);
                });

                $scope.createdState.typeStateRelation.order = $scope.getMaxStateOrder() + 1;
                $scope.createdState.status = "A";
                $scope.wizardTypeData.type.states.push(angular.copy($scope.createdState));

                $scope.createdState = { state: '', final: false, typeStateRelation: { default: false, order: 0, users: [], editors: [], readers: [] }, status: 'A' };
                $scope.useExistingState = true;
                $scope.hideAddStateModalDialog();

                $scope.wizardTypeData.type.states = angular.copy($scope.wizardTypeData.type.states);

                var sirka = $(".tabstrip-states").css("width");
                if (sirka.substr(-2) === "px") {
                    sirka = sirka.substr(0, sirka.length - 2);
                    var cellSize = $scope.cellSize;
                    $(".tabstrip-states").css("width", parseInt(sirka) + parseInt(cellSize) + "px");
                }

                $scope.refresh();

                $scope.sendStateToServer($scope.wizardTypeData.type.states[$scope.wizardTypeData.type.states.length - 1]);
            }
        }
    };

    $scope.getMaxStateOrder = function () {
        var maxOrder = 0;
        angular.forEach($scope.wizardTypeData.type.states, function (state) {
            if (state.typeStateRelation.order > maxOrder) {
                maxOrder = state.typeStateRelation.order;
            }
        });

        return maxOrder;
    };

    $scope.getStateIndexByName = function (stateName) {
        var index = -1;
        for (var i = 0; i < $scope.wizardTypeData.type.states.length; i++) {
            if ($scope.wizardTypeData.type.states[i].state == stateName) {
                index = i;
                break;
            }
        }
        return index;
    };

    $scope.getLastUsedStateIndex = function () {
        var index = -1;
        for (var i = $scope.wizardTypeData.type.states.length - 1; i >= 0; i--) {

            if ($scope.isUsedState($scope.wizardTypeData.type.states[i])) {
                index = i;
                break;
            }
        }
        return index;
    };

    $scope.validateState = function () {
        return !($("#addStateForm").hasClass("ng-invalid"));
    };

    $scope.checkOrClearDefaultState = function (state) {
        if ($scope.lastDefaultState == state.state) {
            for (var i = 0; i < $scope.wizardTypeData.type.states.length; i++) {
                if ($scope.wizardTypeData.type.states[i].state == state.state) {
                    $scope.wizardTypeData.type.states[i].typeStateRelation.default = false;
                    break;
                }
            }
            $scope.lastDefaultState = '';
        } else {
            for (var i = 0; i < $scope.wizardTypeData.type.states.length; i++) {
                if ($scope.wizardTypeData.type.states[i].state != state.state) {
                    $scope.wizardTypeData.type.states[i].typeStateRelation.default = false;
                }
            }
            $scope.lastDefaultState = state.state;
        }

        $scope.sendDefaultStateFlagToServer();
    };

    $scope.sendDefaultStateFlagToServer = function () {

        if ($scope.workOnline) {
            var typ = angular.copy($scope.wizardTypeData);
            typ.type.fields = [];
            var typeData = angular.toJson(typ);
            var statesData = angular.toJson($scope.wizardTypeData.type.states);

            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/SetDefaultState", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData, jsonState: statesData, url: window.location.href }) }).then(
                function successCallback(response) {
                },
                function errorCallback(response) {
                });
        }
    };

    $scope.checkFinalStates = function () {
        var isError = true;
        angular.forEach($scope.wizardTypeData.type.states, function (st) {
            if (st.final && $scope.isUsedState(st)) {
                isError = false;
            }
        });

        if (isError) {
            $(".state-params-final-state-div").addClass("param-error");
            $(".state-params-final-state-div").tooltip({ title: $scope.getLocalString('WZDFinalStateRequired'), placement: 'top' });
        } else {
            $(".state-params-final-state-div").removeClass("param-error");
            $(".state-params-final-state-div").tooltip('destroy');
        }
    };

    $scope.editState = function (state) {
    };

    $scope.deleteState = function (state) {
        $scope.deletingState = state;
        $scope.showDeleteStateModalDialog();
    };

    $scope.doChangeStateFinalFlag = function () {

        $scope.checkFinalStates();
        $scope.hideChangeStateFinalFlagModalDialog();

        $scope.sendStateToServer($scope.stateChangedFinalFlag);
    };

    $scope.discardChangeStateFinalFlag = function () {
        var isFinal = $scope.stateChangedFinalFlag.final;
        $scope.stateChangedFinalFlag.final = !isFinal;
        $scope.hideChangeStateFinalFlagModalDialog();
    };

    $scope.doDeleteState = function () {

        $scope.deletingState.status = "D";

        $scope.hideDeleteStateModalDialog();

        var sirka = $(".tabstrip-states").css("width");
        if (sirka.substr(-2) === "px") {
            sirka = sirka.substr(0, sirka.length - 2);
            var cellSize = $scope.cellSize;
            $(".tabstrip-states").css("width", parseInt(sirka) - parseInt(cellSize) + "px");
        }

        $scope.refresh();

        $scope.sendStateToServer($scope.deletingState);
    };

    /////////////////////////////////////
    // Fields
    /////////////////////////////////////

    $scope.selFieldAdded = function (field) {
        $scope.createdField = field;//angular.copy(field);
        if ($scope.createdField.displayName.length == 0) {
            $scope.createdField.displayName = $scope.createdField.internalName;
        }
        $scope.createdField.createdFieldDisplayName = $scope.createdField.displayName;
    };

    $scope.displayNameChanged = function (displayName) {
        $scope.createdField.displayName = displayName;
    };

    $scope.showNewFieldModalDialog = function () {

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('dokoniCASE.Core'));
        var options = {
            url: urlBase + "fldnew.aspx?IsDlg=1&DisplayNameParam=DCA_&ctype=" + $scope.wizardTypeData.type.id,
            //url: urlBase + "fldnew.aspx?IsDlg=1&DisplayNameParam=DCA_",
            width: 800,
            height: 600,
            dialogReturnValueCallback: $scope.fieldDialogCallback,
            title: $scope.getLocalString('WZDNewFieldProperties'),
            showClose: true
        };

        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    };

    $scope.showEditFieldModalDialog = function (field) {

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('dokoniCASE.Core'));
        var options = {
            url: urlBase + "fldeditEx.aspx?IsDlg=1&CloseOnCancel=1&Field=" + field.internalName + "&ctype=" + $scope.wizardTypeData.type.id,
            //url: urlBase + "fldeditEx.aspx?IsDlg=1&CloseOnCancel=1&Field=" + field.internalName,
            width: 800,
            height: 700,
            dialogReturnValueCallback: $scope.fieldDialogCallback,
            title: $scope.getLocalString('WZDEditFieldProperties'),
            showClose: true
        };

        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    };
    /*
        $scope.showUpdateFieldRequiredItemModalDialog = function (field, state, createNew) {
    
            var recordFound = false;
            var typeData = angular.toJson($scope.wizardTypeData);
    
            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/GetFieldRequiredId", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: state.state, field: field.internalName, createIfNotExists: createNew, url: window.location.href }) }).then(
            function successCallback(response) {
    
                var idStr = angular.fromJson(response.data.d);
                var idNum = parseInt(idStr, 10);
                if (idNum > -1) {
                    var listBase = window.location.href.substring(0, window.location.href.lastIndexOf('_layouts'));
                    dokoniCASECore.OpenInDialogWithCallback(800, 450, false, true, listBase + "/Lists/ConfigurationFieldsRequired/EditForm.aspx?mobile=0&ID=" + idStr, $scope.fieldDialogCallback);
                }
            },
            function errorCallback(response) {
            });
        };
    */
    $scope.showUpdateFieldRequiredItemModalDialog = function (field, state, createNew) {

        var recordFound = false;
        var typeData = angular.toJson($scope.wizardTypeData);

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetFieldRequiredId", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: state.state, field: field.internalName, createIfNotExists: createNew, url: window.location.href }) }).then(
            function successCallback(response) {

                var idStr = angular.fromJson(response.data.d);
                var idNum = parseInt(idStr, 10);
                if (idNum > -1) {

                    var listBase = window.location.href.substring(0, window.location.href.lastIndexOf('_layouts'));
                    var options = {
                        url: listBase + "/Lists/ConfigurationFieldsRequired/EditForm.aspx?mobile=0&ID=" + idStr,
                        width: 800,
                        height: 450,
                        dialogReturnValueCallback: $scope.fieldDialogCallback,
                        title: $scope.getLocalString('WZDFieldRequiredFlagSettingsTitle'),
                        showClose: true
                    };

                    SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                }
            },
            function errorCallback(response) {
            });
    };

    $scope.showChangeRequiredFieldModalDialog = function (field, state, active) {

        if (true/*$scope.workOnline*/) {
            var recordFound = false;
            var typeData = angular.toJson($scope.wizardTypeData);

            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/SetFieldRequired", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ type: $scope.wizardTypeData.type.name, state: state.state, field: field.internalName, active: active, url: window.location.href }) }).then(
                function successCallback(response) {

                    var idStr = angular.fromJson(response.data.d);
                    var idNum = parseInt(idStr, 10);
                },
                function errorCallback(response) {
                });
        }
    };

    $scope.fieldDialogCallback = function (dialogResult, data) {
        $scope.getTypeDataFreeFields(angular.toJson($scope.wizardTypeData));
    }

    $scope.showAddFieldDialog = function () {
        $scope.rereadUnusedFields();

        $scope.createdField = $scope.unusedFields[0];
        if (typeof $scope.createdField === "undefined") {
            $scope.createdField = { id: 1, internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'A', createdFieldDisplayName: '' };
        }

        $scope.createdField.createdFieldDisplayName = "";

        $scope.showAddFieldModalDialog();
    };

    $scope.showAddFieldModalDialog = function () {
        $scope.showAddFieldModal = true;
    };

    $scope.hideAddFieldModalDialog = function () {
        $scope.showAddFieldModal = false;
    };

    $scope.rereadUnusedFields = function () {
        $scope.unusedFields = [];
        angular.forEach($scope.wizardTypeData.type.fields, function (fld) {
            if ((fld.status == 'U') || (fld.status == 'D')) {
                $scope.unusedFields.push(fld);
            }
        });
    };

    $scope.showDeleteFieldModalDialog = function () {
        $scope.showDeleteFieldModal = true;
    };

    $scope.hideDeleteFieldModalDialog = function () {
        $scope.showDeleteFieldModal = false;
    };

    $scope.intNameChanged = function () {
        var i = $scope.createdField.internalName;
    };

    $scope.isFieldRequired = function (field, state) {
        var required = false;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == field.internalName) {

                for (var j = 0; j < $scope.wizardTypeData.type.fields[i].stateFieldRelations.length; j++) {
                    if ($scope.wizardTypeData.type.fields[i].stateFieldRelations[j].state == state.state) {
                        required = $scope.wizardTypeData.type.fields[i].stateFieldRelations[j].required;
                        break;
                    }
                }

                break;
            }
        }
        return required;
    };

    $scope.canFieldChangeRequired = function (field, state) {
        var canChangeRequired = false;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == field.internalName) {

                for (var j = 0; j < $scope.wizardTypeData.type.fields[i].stateFieldRelations.length; j++) {
                    if ($scope.wizardTypeData.type.fields[i].stateFieldRelations[j].state == state.state) {
                        canChangeRequired = $scope.wizardTypeData.type.fields[i].stateFieldRelations[j].canChangeRequired;
                        break;
                    }
                }

                break;
            }
        }
        return canChangeRequired;
    };

    $scope.cannotFieldChangeRequired = function (field, state) {
        var canChangeRequired = $scope.canFieldChangeRequired(field, state);
        return !canChangeRequired;
    };

    $scope.fieldRequiredChanged = function (field, state) {

        var required = false;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == field.internalName) {

                for (var j = 0; j < $scope.wizardTypeData.type.fields[i].stateFieldRelations.length; j++) {
                    var relation = $scope.wizardTypeData.type.fields[i].stateFieldRelations[j];
                    if (relation.state == state.state) {
                        required = !relation.required;
                        relation.required = required;
                        break;
                    }
                }

                break;
            }
        }

        $scope.showChangeRequiredFieldModalDialog(field, state, required);
    };

    $scope.fieldRequiredChangedAll = function (state, status) {

        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            for (var j = 0; j < $scope.wizardTypeData.type.fields[i].stateFieldRelations.length; j++) {
                var relation = $scope.wizardTypeData.type.fields[i].stateFieldRelations[j];
                if (relation.state == state.state) {
                    relation.required = ((status === 'T') || ((status === 'P') && (typeof relation.originalRequired !== "undefined") && (relation.originalRequired === true)));
                    break;
                }
            }
        }
    };

    $scope.fieldEditableChangedAll = function (state, status) {

        angular.forEach($scope.wizardTypeData.type.fields, function (field) {
            for (var j = 0; j < field.stateFieldRelations.length; j++) {
                var relation = field.stateFieldRelations[j];
                if (relation.state == state.state) {
                    $scope.updateFieldEditableFlag(state, field, relation, status);
                    break;
                }
            }
        });
        /////////////////////////////////
    };

    $scope.updateFieldEditableFlag = function (state, field, relation, editableFlag) {

        var usersValue = [];
        var editable = true;
        if (editableFlag === "N") { usersValue = [{ type: 'N' }]; editable = false; }
        if (editableFlag === "P") {
            if ((typeof relation.originalEditable !== "undefined") && (relation.originalEditable === true)) {
                usersValue = [];
                editable = true;
                if (typeof relation.originalEditableUsers !== "undefined") {
                    usersValue = relation.originalEditableUsers;
                }
            } else {
                usersValue = [{ type: 'N' }];
                editable = false;
            }
        }

        var stateObj = state;
        var fieldObj = field;
        var relationObj = relation;

        relationObj.editors = usersValue;
        relationObj.editable = editable;

        // refresh only when field is visible
        if ($scope.isUsedField(fieldObj)) {
            var element = $("div.user-field-permissions-div[userstooltip][field='" + field.internalName + "'][state='" + state.state + "']");
            if (typeof $(element) !== "undefined") {
                element = $(element)[0];
            }
            $(element).attr('users', angular.toJson(usersValue));
            $scope.refreshPermissionsDivByValue2($(element), usersValue);
        }
    };

    $scope.fieldRequiredShowItem = function (field, state) {

        var isActive = false;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == field.internalName) {

                for (var j = 0; j < $scope.wizardTypeData.type.fields[i].stateFieldRelations.length; j++) {
                    if ($scope.wizardTypeData.type.fields[i].stateFieldRelations[j].state == state.state) {
                        isActive = $scope.wizardTypeData.type.fields[i].stateFieldRelations[j].required;
                        break;
                    }
                }

                break;
            }
        }

        $scope.showUpdateFieldRequiredItemModalDialog(field, state);
    };

    $scope.canFieldChangeEditable = function (field, state) {
        var canChangeEditable = false;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == field.internalName) {

                for (var j = 0; j < $scope.wizardTypeData.type.fields[i].stateFieldRelations.length; j++) {
                    if ($scope.wizardTypeData.type.fields[i].stateFieldRelations[j].state == state.state) {
                        canChangeEditable = $scope.wizardTypeData.type.fields[i].stateFieldRelations[j].canChangeEditable;
                        break;
                    }
                }

                break;
            }
        }
        return canChangeEditable;
    };

    $scope.cannotFieldChangeEditable = function (field, state) {
        var canChangeEditable = $scope.canFieldChangeEditable(field, state);
        return !canChangeEditable;
    };

    $scope.editField = function (field) {
        $scope.editedField = angular.copy(field);
        $scope.showEditFieldModalDialog();
    };

    $scope.doEditField = function () {
        if ($scope.validateEditField()) {
            for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
                if ($scope.wizardTypeData.type.fields[i].internalName == $scope.editedField.internalName) {
                    $scope.wizardTypeData.type.fields[i].displayName = $scope.editedField.displayName;
                    $scope.wizardTypeData.type.fields[i].status = "M";
                    break;
                }
            }
            $scope.editedField = { internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'M' };
            $scope.hideEditFieldModalDialog();
        }
    };

    $scope.addField = function () {

        $scope.hideAddFieldModalDialog();

        var field = $scope.createdField;
        if (typeof field === "undefined") {
            $scope.rereadUnusedFields();
            $scope.createdField = $scope.unusedFields[0];

            field = $scope.createdField;
        }

        $scope.appendField(field, true);

        $scope.createdField = { internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'A', createdFieldDisplayName: '' };

        $scope.useExistingField = true;

        var vyska = $(".tabstrip-fields").css("height");
        if (vyska.substr(-2) === "px") {
            vyska = vyska.substr(0, vyska.length - 2);
            var cellSize = $scope.cellSize;
            $(".tabstrip-fields").css("height", parseInt(vyska) + 4 + parseInt(cellSize / 4) + "px");
        }
    };

    $scope.appendField = function (field, addUsed) {

        if (typeof field === "undefined") {
            return;
        }

        field.stateFieldRelations = [];

        var titleField = null;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == 'Title') {
                titleField = $scope.wizardTypeData.type.fields[i];
                break;
            }
        }

        if ((titleField == null) && ($scope.wizardTypeData.type.fields.length > 0)) {
            titleField = $scope.wizardTypeData.type.fields[0];
        }

        if (titleField != null) {
            if (titleField.stateFieldRelations != null) {
                angular.forEach(titleField.stateFieldRelations, function (rel) {
                    var relation = angular.copy(rel);
                    relation.required = false;
                    relation.editable = false;
                    relation.originalRequired = relation.required;
                    relation.originalEditable = relation.editable;
                    field.stateFieldRelations.push(relation);
                });
            }
        }

        field.order = $scope.getMaxFieldOrder() + 1;
        field.typeConfigParams = [];

        var fieldExists = false;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == field.internalName) {
                $scope.wizardTypeData.type.fields[i].displayName = field.displayName;
                $scope.wizardTypeData.type.fields[i].status = (addUsed ? "A" : "U");
                fieldExists = true;
                break;
            }
        }
        if (!fieldExists) {
            field.status = (addUsed ? "A" : "U");
            $scope.wizardTypeData.type.fields.push(angular.copy(field));
        }

        $scope.addOrRemoveFieldOfType(field);
    }

    $scope.addOrRemoveFieldOfType = function (field) {

        if ($scope.workOnline) {
            var fieldData = angular.toJson(field);

            var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
            $http({ method: "POST", url: urlBase + "Wizard.aspx/AddOrRemoveFieldOfType", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ typeName: $scope.wizardTypeData.type.name, field: fieldData, url: window.location.href }) }).then(
                function successCallback(response) {

                    var msg = response;
                    // fetch fields by 20
                    $scope.getTypeDataFreeFields(angular.toJson($scope.wizardTypeData));
                },
                function errorCallback(response) {
                    var error = response;
                });
        }
    };

    $scope.getTypeDataFreeFields = function (typeData) {

        var urlBase = window.location.href.substring(0, window.location.href.lastIndexOf('/') + 1);
        $http({ method: "POST", url: urlBase + "Wizard.aspx/GetAllUnusedFields", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ jsonType: typeData }) }).then(
            function successCallback(response) {

                var typeAllFields = angular.fromJson(response.data.d);
                angular.forEach(typeAllFields.type.fields, function (fld) {
                    var alreadyExists = false;
                    for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
                        if ($scope.wizardTypeData.type.fields[i].internalName == fld.internalName) {
                            //$scope.wizardTypeData.type.fields[i].displayName = fld.displayName;
                            alreadyExists = true;
                            break;
                        }
                    }
                    if (!alreadyExists) {
                        if ((fld.status != "U") && (fld.status != "D") && (fld.status != "A")) {
                            fld.status = "U";
                        }
                        $scope.appendField(fld, false);
                    }
                });

                $scope.rereadUnusedFields();
                if (typeof $scope.createdField === "undefined") {
                    if ($scope.unusedFields.length > 0) {
                        $scope.createdField = $scope.unusedFields[0];
                    }
                }

                if (typeof $scope.createdField !== "undefined") {
                    if ($scope.createdField.displayName == '') {
                        $scope.createdField.displayName = $scope.createdField.internalName;
                    }
                }
            },
            function errorCallback(response, status, error) {
            });
    };

    $scope.getMaxFieldOrder = function () {
        var maxOrder = 0;
        angular.forEach($scope.wizardTypeData.type.fields, function (field) {
            if (field.order > maxOrder) {
                maxOrder = field.order;
            }
        });

        return maxOrder;
    };

    $scope.getFieldIndexByName = function (internalName) {
        var index = -1;
        for (var i = 0; i < $scope.wizardTypeData.type.fields.length; i++) {
            if ($scope.wizardTypeData.type.fields[i].internalName == internalName) {
                index = i;
                break;
            }
        }
        return index;
    };

    $scope.getLastUsedFieldIndex = function () {
        var index = -1;
        for (var i = $scope.wizardTypeData.type.fields.length - 1; i >= 0; i--) {

            if ($scope.isUsedField($scope.wizardTypeData.type.fields[i])) {
                index = i;
                break;
            }
        }
        return index;
    };

    $scope.validateAddField = function () {
        return !($("#addFieldForm").hasClass("ng-invalid"));
    };

    $scope.validateEditField = function () {
        return !($("#editFieldForm").hasClass("ng-invalid"));
    };

    $scope.deleteField = function (field) {
        $scope.deletingField = field;
        $scope.showDeleteFieldModalDialog();
    };

    $scope.doDeleteField = function () {

        var field = angular.copy($scope.deletingField);
        var currentFields = $scope.wizardTypeData.type.fields;
        angular.forEach($scope.wizardTypeData.type.fields, function (fld) {
            if (fld.internalName == $scope.deletingField.internalName) {
                fld.status = "D";
            }
        });
        $scope.deletingField = { internalName: '', displayName: '', type: '', typeConfigParams: [], stateFieldRelations: [], order: 0, status: 'D' };
        $scope.hideDeleteFieldModalDialog();
        $scope.refresh();

        field.stateFieldRelations = [];
        field.status = "D";
        if ($scope.workOnline) {
            $scope.addOrRemoveFieldOfType(field);
        }

        $scope.rereadUnusedFields();

        var vyska = $(".tabstrip-fields").css("height");
        if (vyska.substr(-2) === "px") {
            vyska = vyska.substr(0, vyska.length - 2);
            var cellSize = $scope.cellSize;
            $(".tabstrip-fields").css("height", parseInt(vyska) - 4 - parseInt(cellSize / 4) + "px");
        }
    }

    $scope.initData();

}); // MainCtrl

app.directive('modal', function () {
    return {
        template: '<div class="modal">' +
            '<div class="modal-dialog">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<h4 class="modal-title">{{ title }}</h4>' +
            '</div>' +
            '<div class="modal-body" ng-transclude></div>' +
            '</div>' +
            '</div>' +
            '</div>',
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.title = attrs.title;

            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });
        }
    };
});
