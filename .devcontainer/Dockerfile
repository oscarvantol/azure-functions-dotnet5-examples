FROM mcr.microsoft.com/vscode/devcontainers/dotnetcore:0-5.0

# Adding libdl.so deps
RUN apt-get update && apt-get install -y \
  libc6-dev

RUN curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg \
  && mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg \
  && echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-$(lsb_release -cs)-prod $(lsb_release -cs) main" > /etc/apt/sources.list.d/dotnetdev.list

RUN apt-get update && apt-get install -y \
  azure-functions-core-tools-3