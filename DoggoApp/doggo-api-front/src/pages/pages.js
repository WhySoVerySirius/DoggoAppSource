import Register from "../components/Register";
import Preview from "../components/Preview";
const pages = [
    {
        element : <Register/>,
        path : "/",
        title : "Register"
    },
    {
        element : <Preview/>,
        path : "/preview",
        title : "Preview"
    }
];

export default pages;