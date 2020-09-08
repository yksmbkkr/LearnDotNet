#!groovy
pipeline {
    agent {
        docker {
            image 'yksmbkkr/jdk-dotnetcoresdk:1.0'
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
                dotnet build
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                // export JAVA_HOME="/usr/local/openjdk-11/jre/bin"
                // export PATH="/usr/local/openjdk-11/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/tmp/.dotnet/tools"
                // dotnet tool install --global dotnet-sonarscanner --version 4.10.0
                // dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
                // dotnet build-server shutdown
                // dotnet sonarscanner begin /k:FirstDotNetProject /d:sonar.host.url=http://35.229.248.239:9000 /d:sonar.cs.opencover.reportsPaths=FirstDotNetProject.FirstDotNetProject/coverage.opencover.xml /d:sonar.coverage.exclusions=”**UnitTest*.cs”
                dotnet build
                // dotnet sonarscanner end
                """
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