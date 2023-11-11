import { redirect, type Handle } from '@sveltejs/kit';

export const handle: Handle = async ({ event, resolve }) => {

    let apiKey = event.cookies.get("apiKey") as string;

    if (!apiKey)
        throw redirect(302, "/login");

	return await resolve(event);
};