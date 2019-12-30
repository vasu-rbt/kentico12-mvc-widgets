(function () {
    window.kentico.pageBuilder.registerInlineEditor("page-type-selector", {
        init: function (options) {
            var editor = options.editor;
            var ddl = editor.querySelector("#selector-drop-down");
            if (ddl !== null) {
                ddl.addEventListener("change", function () {
                    var event = new CustomEvent("updateProperty", {
                        detail: {
                            value: ddl.value,
                            name: options.propertyName
                        }
                    });
                    editor.dispatchEvent(event);
                });
            }
        }
    });
})();