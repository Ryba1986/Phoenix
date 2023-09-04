server {
   server_name phoenix.example.com;
   return 301 https://phoenix.example.com$request_uri;
}

server {
   listen                  443 ssl http2;
   server_name             phoenix.example.com;

   access_log              /var/log/nginx/phoenix.example.com.log.access;
   error_log               /var/log/nginx/phoenix.example.com.log.error error;

   ssl_certificate_key     /etc/letsencrypt/live/phoenix.example.com/privkey.pem;
   ssl_certificate         /etc/letsencrypt/live/phoenix.example.com/fullchain.pem;


   location / {
      alias                /var/www/Phoenix.Web/;
      index                index.html;
      try_files            $uri $uri/ /index.html;
   }

   location /apiclient {
      rewrite              ^/apiclient(.*)$ $1 break;
      proxy_pass           http://localhost:5001;
      proxy_http_version   1.1;
      proxy_set_header     Upgrade $http_upgrade;
      proxy_set_header     Connection keep-alive;
      proxy_set_header     Host $host;
      proxy_cache_bypass   $http_upgrade;
      proxy_set_header     X-Forwarded-For $proxy_add_x_forwarded_for;
      proxy_set_header     X-Forwarded-Proto $scheme;
   }

   location /apiweb {
      rewrite              ^/apiweb(.*)$ $1 break;
      proxy_pass           http://localhost:5002;
      proxy_http_version   1.1;
      proxy_set_header     Upgrade $http_upgrade;
      proxy_set_header     Connection keep-alive;
      proxy_set_header     Host $host;
      proxy_cache_bypass   $http_upgrade;
      proxy_set_header     X-Forwarded-For $proxy_add_x_forwarded_for;
      proxy_set_header     X-Forwarded-Proto $scheme;
   }
}
