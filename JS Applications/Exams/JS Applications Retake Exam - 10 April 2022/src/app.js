/*
* Import views
*/
import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";

import { createPage } from "./views/create.js";
import { dashboardPage } from "./views/dashboard.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { loginPage } from "./views/login.js";
import { logoutPage } from "./views/logout.js";
import { updateNav } from "./views/nav.js";
import { registerPage } from "./views/register.js";
import { getUserData } from "./util.js";
import { myPostsPage } from "./views/myPosts.js";


//get main element for render:
const main = document.querySelector('main');

//attach middleWare:

/*
* Create page routing
*/
updateNav();

page(decorateContext);
page('/', dashboardPage);
page('/create', createPage);
page('/dashboard', dashboardPage);
page('/myPosts', myPostsPage);
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