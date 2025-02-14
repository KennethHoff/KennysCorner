// @ts-check
import { defineConfig } from 'astro/config';

import tailwindcss from '@tailwindcss/vite';

import sitemap from '@astrojs/sitemap';

// https://astro.build/config
export default defineConfig({
        site: 'http://localhost:4321',
        vite: {
                plugins: [tailwindcss()]
        },

        integrations: [sitemap()]
});
