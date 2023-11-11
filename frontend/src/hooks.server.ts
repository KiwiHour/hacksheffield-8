import { redirect, type Handle } from '@sveltejs/kit';

export const handle: Handle = async ({ event, resolve }) => {

    console.log("ok")
    let apiKey = event.cookies.get("apiKey") as string;

    if (!apiKey && event.url.pathname != "/login") {
        throw redirect(302, "/login");
    }

	return await resolve(event);
};