// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('click', '[data-del-confirm]', function (e) {
    e.preventDefault(); // Prevent the default link behavior

    const message = $(this).data('del-confirm');
    if (confirm(message)) {
        // If user confirms, navigate to the link's href
        window.location.href = $(this).attr('href');
    }
});

$(document).ready(function () {
    $('#summernote').summernote({
        height: 300,
        placeholder: 'Write your content here...',
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'italic', 'underline', 'clear']],
            ['fontname', ['fontname']],
            ['fontsize', ['fontsize']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link', 'picture', 'video']],
            ['view', ['fullscreen', 'codeview', 'help']]
        ]
    });
});

$(document).ready(function () {
    let table = $('#dataTable').DataTable({
        responsive: true,
        info: false,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/cs.json'
        },

        rowReorder: {
            selector: 'td:nth-child(3)'
        }


    });

    
});


