# Импортируем библиотеки
from sklearn import datasets
import matplotlib.pyplot as plt
import pandas as pd
from pandas.io.json import json_normalize 
import json
import requests
import copy


#data = pd.read_json('http://188.130.135.206:1488/api/EmployeeRecommendation/1', orient = 'split')

#Входные параметры списки c словаряим компетенций сотрудника и специальности
def get_competency_level(employeeCompetency, targetCompetency):
    value = 0.0
    for target in targetCompetency:
        isFound = False
        for empl in employeeCompetency:
            
            print(target, empl)
            if target['competency']['id'] == empl['competency']['id']:
                isFound = True
                if (target['level'] - empl['level'] ) >=0:    
                    value += (target['level'] - empl['level']) * target['weight']
                else:
                    value += 0.0
        if not isFound:
            value += target['level'] * target['weight']            
    #    setEmployeeCompetency = set()
#    setTargetCompetency = set()
#    for emp in employeeCompetency:
#        setEmployeeCompetency.add(emp['id'])
#    for tar in targetCompetency:
#        setTargetCompetency.add(tar['id'])
#    value = len(setEmployeeCompetency & setTargetCompetency)
    return value
    
    
response = requests.get('http://188.130.135.206:1488/api/employee')
employees = json.loads(response.text)
dataReturn =[]
response = requests.get('http://188.130.135.206:1488/api/jobtitle')
jobTitles = json.loads(response.text)
#алгоритм сравнения и подборнаиболее подходящей
for empl in employees:
    ## Сотрудник
    employeeCompetency = empl['competencies'] # список компетенций сотрудника
    ##############
    #Находим актуальную работу сотрудника
    #####################3
    actualJobId = empl['jobHistory']
    countJob = len(actualJobId)-1
    actualJobId = actualJobId[countJob]
    actualJobId = actualJobId['id']#id актуальной работы

    for job in jobTitles:
        dictReturn = {} 
        couercesReturn = {}
        idJob = job['id']
        if idJob != actualJobId:
            dictReturn['positionId'] = idJob
            dictReturn['employeeId'] = empl['id']
            print(idJob)
            dictReturn['distance'] = get_competency_level(employeeCompetency,job['requiredCompetency'])
            dictReturn['courseIds'] = []
            dataReturn.append(dictReturn)
            


tds_monthly_totals.iplot(
    mode='lines+markers+text',
    text=text,
    y='word_count',
    opacity=0.8,
    xTitle='Date',
    yTitle='Word Count',
    title='Total Word Count by Month')

print(dataReturn) 
urlPut = 'http://188.130.135.206:1488/api/EmployeeRecommendation/'

headers = {"Content-Type": "application/json"}

#try:
##    response = requests.post(urlPut, data=json.dumps(dataReturn), headers=headers)
#except:    
#    i = 1
        
