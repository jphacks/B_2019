var FileDownloadPlugin = {
    FileDownLoad: function(pImage , size, pStr) {
        var mimeType = 'data:image/png;base64';
        var filename = Pointer_stringify(pStr);
        var binary = new ArrayBuffer(size);
        var dv = new DataView(binary);
 
        for (var i = 0; i < size; i++)
            dv.setUint8(i, HEAPU8[pImage + i]);
        var blob = new Blob([binary], {type : mimeType});
        const a = document.createElement('a');
        a.href = window.URL.createObjectURL(blob);
        a.download = filename;
        a.style.display = 'none';
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
    }
}
mergeInto(LibraryManager.library, FileDownloadPlugin);
