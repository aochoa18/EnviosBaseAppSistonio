//"use strict";
//// Class definition

//var KTDatatableHtmlTableDemo = function () {
//    // Private functions

//    // demo initializer
//    var demo = function () {

//        var datatable = $('#kt_datatable').KTDatatable({
//            data: {
//                saveState: { cookie: false },
//            },
//            search: {
//                input: $('#kt_datatable_search_query'),
//                key: 'generalSearch'
//            },
//        });

//        $('#kt_datatable_search_status').on('change', function () {
//            datatable.search($(this).val().toLowerCase(), 'Status');
//        });

//        $('#kt_datatable_search_type').on('change', function () {
//            datatable.search($(this).val().toLowerCase(), 'Type');
//        });

//        $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();

//    };

//    return {
//        // Public functions
//        init: function () {
//            // init dmeo
//            demo();
//        },
//    };
//}();

//jQuery(document).ready(function () {
//    KTDatatableHtmlTableDemo.init();
//});


"use strict";
// Class definition

var KTDatatableHtmlTableDemo = function () {
    // Private functions

    // demo initializer
    var demo = function () {

        var datatable = $('#example2').KTDatatable({
            data: {
                saveState: { cookie: false },
            },
            columns: [
                {
                    field: 'Id',
                    type: 'number',
                    width: 60
                },
            ],
            search: {
                input: $('#example2_search_query'),
                key: 'generalSearch'
            }
        });

        $('#example2_search_status').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Status');
        });

        $('#example2_search_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Type');
        });

        $('#example2_search_status, #example2_search_type').selectpicker();

    };

    return {
        // Public functions
        init: function () {
            // init dmeo
            demo();
        },
    };
}();

jQuery(document).ready(function () {
    KTDatatableHtmlTableDemo.init();
});
