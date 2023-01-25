(function ($) {
    function jobapplicationIndex() {
        var $this = this;

        function initializejobapplicationGrid() {
            if ($.fn.DataTable.isDataTable($this.jobapplicationGrid)) {
                $($this.jobapplicationGrid).DataTable().destroy();
            }
            $this.toiletryParcelGrid = new Global.GridAjaxHelper('#grid-jobapplication', {
                "aoColumns": [
                    { "sName": "ParcelTypeId1" },
                    { "sName": "S.NO" },
                    { "sName": "JobCode" },
                    { "sName": "Title" },
                    { "sName": "MinimumQualification" },
                    { "sName": "SortDescription" },
                    {
                        "sName": ""
                    },
                ],
                "bStateSave": false,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [1, 6] }, { 'visible': false, 'aTargets': [0, 1] }],
            }, "JobApplication/Index",
            );
            $("#grid-jobapplication").parent("div").parent("div").addClass("table-responsive");
            $this.toiletryParcelGrid.on('search.dt', function () {
                Global.DataServer.dataURL = "JobApplication/Index";
            });
            $this.toiletryParcelGrid.on('length.dt', function () {
                Global.DataServer.dataURL = "JobApplication/Index";
            });
        }

        $this.init = function () {
            initializejobapplicationGrid();

        }
    }

    $(
        function () {
            var self = new jobapplicationIndex();
            self.init();
        }
    )
})(jQuery)