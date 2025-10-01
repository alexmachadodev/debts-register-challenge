# Stage 1: Build the Angular application
FROM node:20-alpine AS builder
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build -- --configuration production

# Stage 2: Serve the application from a lightweight web server
FROM nginx:alpine
COPY --from=builder /app/dist/debts-register-challenge-app/browser /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80