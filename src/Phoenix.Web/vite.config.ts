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
   plugins: [vue()],
});
