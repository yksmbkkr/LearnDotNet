#!groovy
pipeline {
    agent {
        docker {
            image 'nosinovacao/dotnet-sonar:20.07.0'
        }
    }
    environment {
        HOME = '/tmp'
    } 
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh """
                #!/bin/bash
                dotnet build FirstDotNetProject.sln
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
                """
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh """
                    #!/bin/bash
                    dotnet build-server shutdown
                    ls
                    ls FirstDotNetProject
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll begin /k:FirstDotNetProject /d:sonar.host.url=http://35.229.248.239:9000 /d:sonar.login="863375e933a566953f21126b24042bde76669dd7" /d:sonar.cs.opencover.reportsPaths=FirstDotNetProject/coverage.opencover.xml /d:sonar.coverage.exclusions=”**UnitTest*.cs”
                    dotnet build FirstDotNetProject.sln
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll /d:sonar.login="863375e933a566953f21126b24042bde76669dd7" end 
                    """
                }
            }
        }
        stage("Quality Gate") {
            steps {
              timeout(time: 5, unit: 'MINUTES') {
                waitForQualityGate abortPipeline: true
              }
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                dotnet run --project FirstDotNetProject
                """
            }
        }
    }
    post {
        always {
            emailext body: '$DEFAULT_CONTENT', recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']], subject: '$DEFAULT_SUBJECT', replyTo: '$DEFAULT_REPLYTO'
        }
    }
}