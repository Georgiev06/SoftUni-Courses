import { html } from "../../node_modules/lit-html/lit-html.js"
import { getAllJobOffers } from "../api/data.js";

const dashboardTemplate = (jobOffers) => html`
<section id="dashboard">
    <h2>Job Offers</h2>

    ${jobOffers.length != 0 ? jobOffers.map(job => jobOfferCardTemplate(job)) : html`<h2>No offers yet.</h2>`}
</section>
`;

const jobOfferCardTemplate = (job) => html`
    <div class="offer">
        <img src="${job.imageUrl}" alt="example1" />
        <p>
            <strong>Title: </strong><span class="title">${job.title}</span>
        </p>
        <p><strong>Salary:</strong><span class="salary">${job.salary}</span></p>
        <a class="details-btn" href="/details/${job._id}">Details</a>
    </div>
`;

export async function dashboardPage(ctx) {
    const jobOffers = await getAllJobOffers();
    ctx.render(dashboardTemplate(jobOffers))
}