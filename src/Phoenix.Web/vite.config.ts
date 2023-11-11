import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
   build: {
      chunkSizeWarningLimit: 4096,
      emptyOutDir: true,
      outDir: '../../dist/Phoenix.Web',
      reportCompressedSize: false,
   },
   plugins: [vue()],
   server: {
      proxy: {
         '/apiweb': {
            target: 'http://127.0.0.1:5002',
            changeOrigin: true,
            secure: false,
            rewrite: (path) => path.replace(/^\/apiweb/, ''),
         },
      },
   },
});
