# Gotten here : 
# https://blogs.msdn.microsoft.com/webdev/2017/02/20/lets-try-wcf-self-hosted-services-in-a-container/
# Start with Windows Server Core image

FROM microsoft/windowsservercore

RUN powershell -Command Add-WindowsFeature NET-WCF-HTTP-Activation45


# Directory for the host
WORKDIR app

# Port
EXPOSE 8733

# Copy the WCF host into the container
COPY Bin/ .

ENTRYPOINT MathsLibrary.exe
