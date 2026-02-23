let signalColor = "green"; 
switch (signalColor.toLowerCase()) {
    case "red":
        console.log("Stop");
        break;
    case "yellow":
        console.log("Get Ready");
        break;
    case "green":
        console.log("Go");
        break;
    default:
        console.log("Invalid signal color. Please enter red, yellow, or green.");
        break;
}