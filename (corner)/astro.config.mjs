// @ts-check

import sitemap from "@astrojs/sitemap";
import vercel from "@astrojs/vercel";
import tailwindcss from "@tailwindcss/vite";
import { defineConfig } from "astro/config";
import react from "@astrojs/react";
import icon from "astro-icon";
import mdx from "@astrojs/mdx";

const siteUrl =
        // If Production, use production URL
        process.env.VERCEL_ENV == "production"
                ? `https://${process.env.VERCEL_PROJECT_PRODUCTION_URL}`
                : // Otherwise, if you have a VERCEL_URL, use it
                process.env.VERCEL_URL
                        ? `https://${process.env.VERCEL_URL}`
                        : // Otherwise, just use localhost.
                        "http://localhost:4322";

export default defineConfig({
        site: siteUrl,
        server: {
                port: 4322
        },
        vite: {
                plugins: [tailwindcss()],
        },
        integrations: [sitemap(), react(), icon(), mdx()],
        adapter: vercel(),
        trailingSlash: "never",
        redirects: {
                "/resume": {
                        status: 301,
                        destination: "https://www.kennethhoff.no/resume"
                }
        }
});
