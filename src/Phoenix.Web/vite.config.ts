import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vitejs.dev/config/
export default defineConfig({
   build: {
      chunkSizeWarningLimit: 4096,
      emptyOutDir: true,
      outDir: "../../dist/Phoenix.Web",
      reportCompressedSize: false,
   },
   plugins: [
      vue({
         template: {
            compilerOptions: {
               isCustomElement: (tag) => {
                  return tag === "svg:style";
               },
            },
         },
      }),
   ],
   resolve: {
      alias: {
         "devextreme/ui": "devextreme/esm/ui",
      },
   },
   server: {
      proxy: {
         "/apiweb": {
            target: "http://127.0.0.1:5002",
            changeOrigin: true,
            secure: false,
            rewrite: (path) => path.replace(/^\/apiweb/, ""),
         },
      },
   },
});
