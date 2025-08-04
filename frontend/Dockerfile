# Estágio de build
FROM node:20-alpine AS builder

WORKDIR /app

# Primeiro copia os arquivos de definição de dependências
COPY package.json package-lock.json* ./

# Instala as dependências
RUN npm ci --legacy-peer-deps

# Copia o restante dos arquivos
COPY . .

# Executa o build
RUN npm run build -- --configuration production

# Estágio de produção
FROM nginx:alpine
COPY --from=builder /app/dist/seu-projeto /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]