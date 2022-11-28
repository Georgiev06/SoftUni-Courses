import { html, render } from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs'
import * as api from './api/api.js'

import { createPage } from './views/create.js';
import { dashboardPage } from './views/dashboard.js';
import { deletePage } from './views/delete.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { logoutPage } from './views/logout.js';
import { registerPage } from './views/register.js';
import { searchPage } from './views/search.js';

window.api = api;

const root = document.querySelector('nav');
const main = document.querySelector('main');

page(decorateContext)
page('/', homePage);
page('/dashboard', dashboardPage);
page('/register', registerPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/delete/:id', deletePage);
page('/search', searchPage);

page.start();

updateNav();

export function updateNav() {
    const authToken = sessionStorage.getItem('authToken');

    let navTemplate;
    if (authToken) {
        navTemplate = () => html`
        <div>
            <a href="/dashboard">Dashboard</a>
            <a href="/search">Search</a>
        </div>
        <div class="user">
            <a href="/create">Add Pair</a>
            <a href="/logout">Logout</a>
        </div>`;
    }
    else {
        navTemplate = () => html`
        <div>
            <a href="/dashboard">Dashboard</a>
            <a href="/search">Search</a>
        </div>
        <div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>`;
    }

    render(navTemplate(), root);
}

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    next();
}

function renderMain(content) {
    render(content, main);
}
