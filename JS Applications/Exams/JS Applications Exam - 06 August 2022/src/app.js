/*
* Import views
*/
import { getUserData } from "./util.js";
import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { createPage } from "./views/create.js";
import { dashboardPage } from "./views/dashboard.js";
import { detailsPage } from "./views/details.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { logoutPage } from "./views/logout.js";
import { registerPage } from "./views/register.js";
import { updateNav } from "./views/nav.js";
import { editPage } from './views/edit.js';

//get main element for render:
const main = document.querySelector('main');

//attach middleWare:

/*
* Create page routing
*/
updateNav()

page(decorateContext);
page('/', homePage);
page('/create', createPage);
page('/dashboard', dashboardPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/register', registerPage);

page.start()

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUserData();

    if (user) {
        ctx.user = user;
    }

    next();
}

function renderMain(content) {
    render(content, main);
}