//Run this on the console for the given archive's 'Download All' page
//That page has all the links to the archive's files

var files = [];

$('.directory-listing-table > tbody > tr > td > a').each(function () {
    var file = $(this).attr('href');
    if (file.indexOf('.mp3') >= 0) //only include mp3 files
        files.push({
            Name: file,
            Link: window.location.href + '/' + file
        });
});

var FileContainer = {
    Files: files
};

JSON.stringify(FileContainer);