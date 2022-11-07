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


## Tutorial 1 - Intro

1. Hello Tracing
2. Add Activity/Span.
3. No-op !!
4. Add ConsoleExporter
5. Add Jaeger Exporter --if time good

## Tutorial 2 - Geneva 

6. Add GenevaExporter
   Nothing happens....

   Jarvis + GCS config + Cert. Use the script from GCS to launch agent
   Pay attention to Cert thumbprint, GCS version
   
   Also mention the basicconfig
   
9. Rerun the app.
10. Show again that table2csv can still be used.
11. Show telemetry in Jarvis

## Tutorial 3 - More Activity, Distributed Tracing in Geneva

More Activity/Span
TraceContext, Propagation
Enable DT in Config
Jarvis Trace Explorewr

## Tutorial 4 - Logging 

Add Logs
Correlation

## Tutorial 5 - Asp.Net Core Application

Add Tracing with instrumentation libraries
Add logging.
Host logs vs logs in request context.
Make a request fail.

Local Agent Validation for almost all troubleshooting.

## Break 

## Intermediate Level topics - Tracing

Advanced sampling - defer to later sessions
Add more tags from Controller
Activity.Current?.SetTag("CustomKey", "CustomValue");
Enrich/Filter using instrumentation libraries
Enrich/Filter using processor.

Do live. Walk through the process of how to do things in OTel
land.

## Intermediate Level topics - Logging

Structured Log

### Geneva Specific capabilities
Schema Explosion
TableName Mappings

## OSS Tools like Jaeger