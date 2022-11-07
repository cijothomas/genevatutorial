# genevatutorial

## Geneva account 
cd C:\genevamonitoringagent.45.12.1\Monitoring\Agent
set MONITORING_DATA_DIRECTORY=%LocalAppData%\Monitoring
set MONITORING_TENANT=%USERNAME%
set MONITORING_ROLE=IFxSDKCI
set MONITORING_ROLE_INSTANCE=%COMPUTERNAME%
set MONITORING_GCS_ENVIRONMENT=Test
set MONITORING_GCS_ACCOUNT=IFxSDKCI
set MONITORING_GCS_NAMESPACE=IFxSDKCI
set MONITORING_GCS_REGION=westus
set MONITORING_GCS_THUMBPRINT=9A797CED79B78A91A3EE4E8D4837AD3B8913F14C
set MONITORING_GCS_CERTSTORE=LOCAL_MACHINE\MY
set MONITORING_CONFIG_VERSION=2.10
set MDM_MONITORING_ACCOUNT=
MonAgentLauncher.exe -useenv

## Full local
cd C:\genevamonitoringagent.45.12.1\Monitoring\Agent
set MONITORING_TENANT=tenant
set MONITORING_ROLE=role
set MONITORING_ROLE_INSTANCE=instance
set MONITORING_DATA_DIRECTORY=C:\genevamonitoringagent.45.12.1\data
set MONITORING_INIT_CONFIG=C:\genevamonitoringagent.45.12.1\basicconfig.xml
MonAgentLauncher.exe -useenv

## Table2csv
c:\genevamonitoringagent.45.12.1\Monitoring\Agent\table2csv.exe  -query "" Log.tsf


Tutorial1
1. Hello Tracing
2. Add Activity code.
3. Show that its no-op.
4. Add ConsoleExporter
5. Add Jaeger Exporter --if time good

Tutorial2
6. Add GenevaExporter
   Nothing happens....

   Jarvis + GCS config + Cert. Use the script from GCS to launch agent
   Show the cert thumbprint change required.
   
   Also mention the basicconfig
   
9. Rerun the app.
10. Show again that table2csv can still be used.
11. Show telemetry in Jarvis

Tutorial3
Nested Activity
Explain TraceContext, Propagation, 
Show DT Config
See if Jarvis has e2e view ready

Tutorial4
Add Logs and show they are correlated



Switch to Asp.Net Core App
Add Tracing and show instrumentation libraries
Show logging, and compare with Console (Logger factory)
Show that host logs are missing dt...
Show logs, failed request (500)


Reiterate Agent local validation, and the fully local agent config without GCS


=============5 min break=================================
Intermediate level topic
Advanced sampling - defer to later sessions

Add more tags from Controller
Activity.Current?.SetTag("CustomKey", "CustomValue");

Enrich/Filter using instrumentation libraries


Enrich/Filter using processor.




====
Key Takeway, and try to get that in initial 10-15 mins.
Consider showing local Jaeger.
====