(function () { // робить local область видимості

    var onIsDoneClick = function (e) {
        console.log("[tasks-page] - checkbox click", arguments);
        var ch = e.target;
        var isDone = ch.checked;
        if (isDone == true) {
            var Id = ch.getAttribute("data-task-id");

            console.log(Id);

            $.ajax({
                url: "/Task/ChangeStatus",
                type: "POST",
                dataType: "text",
                data: {
                    taskId: Id,
                    isDone: isDone
                }
            });

            $("input[type='checkbox'][data-task-id=" + Id + "]").attr("disabled", true);
        }
    };

    var onSelectClick = function (e) {
        var s = $("#select_search option:selected").text();
        $("#select_hidden").val(s);
    };

    var init = function () {
        console.log("[tasks-page] - init");

        var ch = $("input[type='checkbox'][checked='checked']").attr("disabled", true);
        //
        //console.log("");

        $("input[type='checkbox']").on("click", onIsDoneClick);


        var s = $("#select_hidden").val();
         $("#select_search option[value="+s+"]").attr("selected", "selected");


        $("#select_search").on( "click", onSelectClick );
    };


    $(function () { // main - точка входу ( після повної загрузки сторінки )
        console.log("[tasks-page] - test");
        init();
    });
})();