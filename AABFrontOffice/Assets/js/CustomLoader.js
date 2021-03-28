function hideLoader() {


    $.LoadingOverlay("hide");
}




function showLoader() {
    const config = {
        // Background
        background: "rgba(255, 255, 255, 0.8)",
        backgroundClass: "",
         // Image
        image: "/Assets/images/loader-logo.png",
        imageAnimation: "2000ms fadein",
        imageAutoResize: true,
        imageResizeFactor: 2,
        imageColor: "#202020",
        imageClass: "",
        imageOrder: 1,
        // Font Awesome
        fontawesome: "",
        fontawesomeAnimation: "",
        fontawesomeAutoResize: true,
        fontawesomeResizeFactor: 1,
        fontawesomeColor: "#202020",
        fontawesomeOrder: 2,
        // Custom
        custom: "",
        customAnimation: "",
        customAutoResize: true,
        customResizeFactor: 1,
        customOrder: 3,
        // Text
        text: "Loading...",
        textAnimation: "",
        textAutoResize: true,
        textResizeFactor: 0.1,
        textColor: "#202020",
        textClass: "",
        textOrder: 1,
        // Progress
        progress: false,
        progressAutoResize: true,
        progressResizeFactor: 0.25,
        progressColor: "#a0a0a0",
        progressClass: "",
        progressOrder: 5,
        progressFixedPosition: "",
        progressSpeed: 200,
        progressMin: 0,
        progressMax: 100,
        // Sizing
        size: 50,
        maxSize: 150,
        minSize: 40,
        // Misc
        direction: "column",
        fade: true,
        resizeInterval: 50,
        zIndex: 2147483647
    };

    $.LoadingOverlay("show", config);
}