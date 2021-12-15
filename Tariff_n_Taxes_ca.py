class StepTariffOne:
    def __init__(self, ListOfTariffs):
        # self.StepOne = [0, 50, 38, False, 0, True, 20]
        # self.StepTwo = [51, 100, 48, False, 0, True, 40]
        # self.StepThree = [101, 200, 65, True, 22.65, True, 60]
        # self.StepFour = [201, 350, 96, False, 0, True, 80]
        # self.StepFive = [351, 650, 118, False, 0, True, 100]
        # self.StepSix = [651, 1000, 140, True, 282, True, 120]
        # self.StepSeven = [1001, 10000, 200, True, 600, True, 140]



        self.StepOne = [int(ListOfTariffs[0][0]), int(ListOfTariffs[0][1]), int(ListOfTariffs[0][2]), self.BoolCast(ListOfTariffs[0][3]), int(ListOfTariffs[0][4]), self.BoolCast(ListOfTariffs[0][5]), int(ListOfTariffs[0][6])]
        self.StepTwo = [int(ListOfTariffs[1][0]), int(ListOfTariffs[1][1]), int(ListOfTariffs[1][2]), self.BoolCast(ListOfTariffs[1][3]), int(ListOfTariffs[1][4]), self.BoolCast(ListOfTariffs[1][5]), int(ListOfTariffs[1][6])]
        self.StepThree = [int(ListOfTariffs[2][0]), int(ListOfTariffs[2][1]), int(ListOfTariffs[2][2]), self.BoolCast(ListOfTariffs[2][3]), int(ListOfTariffs[2][4]),self.BoolCast( ListOfTariffs[2][5]), int(ListOfTariffs[2][6])]
        self.StepFour = [int(ListOfTariffs[3][0]), int(ListOfTariffs[3][1]), int(ListOfTariffs[3][2]), self.BoolCast(ListOfTariffs[3][3]), int(ListOfTariffs[3][4]), self.BoolCast(ListOfTariffs[3][5]), int(ListOfTariffs[3][6])]
        self.StepFive = [int(ListOfTariffs[4][0]), int(ListOfTariffs[4][1]), int(ListOfTariffs[4][2]), self.BoolCast(ListOfTariffs[4][3]), int(ListOfTariffs[4][4]),self.BoolCast( ListOfTariffs[4][5]), int(ListOfTariffs[4][6])]
        self.StepSix = [int(ListOfTariffs[5][0]), int(ListOfTariffs[5][1]), int(ListOfTariffs[5][2]),self.BoolCast( ListOfTariffs[5][3]), int(ListOfTariffs[5][4]), self.BoolCast(ListOfTariffs[5][5]), int(ListOfTariffs[5][6])]
        self.StepSeven = [int(ListOfTariffs[6][0]), int(ListOfTariffs[6][1]), int(ListOfTariffs[6][2]), self.BoolCast(ListOfTariffs[6][3]), int(ListOfTariffs[6][4]), self.BoolCast(ListOfTariffs[6][5]), int(ListOfTariffs[6][6])]


        #self.StepOne = [1, 2000, 38, False, 0, True, 20]
        #self.StepTwo = [2001, 4000, 48, False, 0, True, 40]
        #self.StepThree = [4001, 5000, 65, True, 88, True, 60]
        #self.StepFour = [5001, 6000, 96, False, 0, True, 80]
        #self.StepFive = [6001, 7000, 118, False, 0, True, 100]
        #self.StepSix = [7001, 8000, 140, True, 441, True, 120]
        #self.StepSeven = [8001, 9000, 200, True, 480, True, 140]
        self.StepsLists = [self.StepOne, self.StepTwo, self.StepThree, self.StepFour, self.StepFive, self.StepSix, self.StepSeven]
        self.delta_list = []
        self.delta(1000)

    def BoolCast(self, StringInput):
        if StringInput == "True":
            return True
        else:
            return False

    def returnList(self):
        return self.StepsLists


    def check_credit(self, current_credit,last_credit):
        if current_credit == last_credit:
            return True
        else:
            return False
    def delta(self, scaler):
        list_ran = len(self.StepsLists)
        for i in range(0, (len(self.StepsLists))):
            if self.StepsLists[i][3]:
                acc_cost = (self.StepsLists[i][0] - 1) / scaler * self.StepsLists[i][2]
                pre_cost = 0
                j = 0
                while j < (i):
                    if self.StepsLists[j][3]:
                        pre_cost = self.StepsLists[j][1] / scaler * self.StepsLists[j][2]
                    else:
                        pre_cost += (self.StepsLists[j][1] - self.StepsLists[j][0] + 1) / scaler * self.StepsLists[j][2]
                    j += 1
                self.delta_list.append(acc_cost - pre_cost)
            else:
                    self.delta_list.append(0)
        self.StepsLists[i][4] = self.delta_list[i]

    def per_kwh_cost(self, current_power_consumption, radio_tax_value, consumption_tax_value):
        if (current_power_consumption % 1000 == 0) and current_power_consumption > 0:
            return self.cost_calculator_kwh(current_power_consumption) + \
                      self.radio_tax(current_power_consumption, radio_tax_value) + \
                      self.consumption_tax(current_power_consumption, consumption_tax_value)
        else:
            return 0

    def consumption_tax(self, current_power_consumption, tax_value):
        if current_power_consumption % 2000 == 0:
            return tax_value
        else:
            return 0

    def radio_tax(self, current_power_consumption, tax_value):
        if current_power_consumption <= 8000:
            return tax_value
        else:
            return 0

    def cost_calculator_kwh(self, current_power_consumption):
        if current_power_consumption < self.StepTwo[0]:
            if self.StepOne[3]:
                self.StepOne[3] = False
                if self.StepOne[5] and (current_power_consumption == (self.StepOne[0] + 999)):
                    self.StepOne[5] = False
                    return self.StepOne[2] + self.StepOne[4] + self.StepOne[6]
                else:
                    return self.StepOne[2] + self.StepOne[4]
            else:
                if self.StepOne[5] and (current_power_consumption == (self.StepOne[0] + 999)):
                    self.StepOne[5] = False
                    return self.StepOne[2] + self.StepOne[6]
                else:
                    return self.StepOne[2]

        elif current_power_consumption < self.StepThree[0]:
            if self.StepTwo[3]:
                self.StepTwo[3] = False
                if self.StepTwo[5] and (current_power_consumption == (self.StepTwo[0] + 999)):
                    self.StepTwo[5] = False
                    return self.StepTwo[2] + self.StepTwo[4] + self.StepTwo[6]
                else:
                    return self.StepTwo[2] + self.StepTwo[4]
            else:
                if self.StepTwo[5] and (current_power_consumption == (self.StepTwo[0] + 999)):
                    self.StepTwo[5] = False
                    return self.StepTwo[2] + self.StepTwo[6]
                else:
                    return self.StepTwo[2]

        elif current_power_consumption < self.StepFour[0]:
            if self.StepThree[3]:
                self.StepThree[3] = False
                if self.StepThree[5] and (current_power_consumption == (self.StepThree[0] + 999)):
                    self.StepThree[5] = False
                    return self.StepThree[2] + self.StepThree[4] + self.StepThree[6]
                else:
                    return self.StepThree[2] + self.StepThree[4]
            else:
                if self.StepThree[5] and (current_power_consumption == (self.StepThree[0] + 999)):
                    self.StepThree[5] = False
                    return self.StepThree[2] + self.StepThree[6]
                else:
                    return self.StepThree[2]

        if current_power_consumption < self.StepFive[0]:
            if self.StepFour[3]:
                self.StepFour[3] = False
                if self.StepFour[5] and (current_power_consumption == (self.StepFour[0] + 999)):
                    self.StepFour[5] = False
                    return self.StepFour[2] + self.StepFour[4] + self.StepFour[6]
                else:
                    return self.StepFour[2] + self.StepFour[4]
            else:
                if self.StepFour[5] and (current_power_consumption == (self.StepFour[0] + 999)):
                    self.StepFour[5] = False
                    return self.StepFour[2] + self.StepFour[6]
                else:
                    return self.StepFour[2]

        if current_power_consumption < self.StepSix[0]:
            if self.StepFive[3]:
                self.StepFive[3] = False
                if self.StepFive[5] and (current_power_consumption == (self.StepFive[0] + 999)):
                    self.StepFive[5] = False
                    return self.StepFive[2] + self.StepFive[4] + self.StepFive[6]
                else:
                    return self.StepFive[2] + self.StepFive[4]
            else:
                if self.StepFive[5] and (current_power_consumption == (self.StepFive[0] + 999)):
                    self.StepFive[5] = False
                    return self.StepFive[2] + self.StepFive[6]
                else:
                    return self.StepFive[2]

        if current_power_consumption < self.StepSeven[0]:
            if self.StepSix[3]:
                self.StepSix[3] = False
                if self.StepSix[5] and (current_power_consumption == (self.StepSix[0] + 999)):
                    self.StepSix[5] = False
                    return self.StepSix[2] + self.StepSix[4] + self.StepSix[6]
                else:
                    return self.StepSix[2] + self.StepSix[4]
            else:
                if self.StepSix[5] and (current_power_consumption == (self.StepSix[0] + 999)):
                    self.StepSix[5] = False
                    return self.StepSix[2] + self.StepSix[6]
                else:
                    return self.StepSix[2]

        else:
            if self.StepSeven[3]:
                self.StepSeven[3] = False
                if self.StepSeven[5] and (current_power_consumption == (self.StepSeven[0] + 999)):
                    self.StepSeven[5] = False
                    return self.StepSeven[2] + self.StepSeven[4] + self.StepSeven[6]
                else:
                    return self.StepSeven[2] + self.StepSeven[4]
            else:
                if self.StepSeven[5] and (current_power_consumption == (self.StepSeven[0] + 999)):
                    self.StepSeven[5] = False
                    return self.StepSeven[2] + self.StepSeven[6]
                else:
                    return self.StepSeven[2]






StepOne=["1","2000","38","False","0","True","20"]
StepTwo=["2001","4000","48","False","0","True","40"]
StepThree=["4001","5000","65","True","88","True","60"]
StepFour=["5001","6000","96","False","0","True","80"]
StepFive=["6001","7000","118","False","0","True","100"]
StepSix=["7001","8000","140","True","441","True","120"]
StepSeven=["8001","9000","200","True","480","True","140"]

StepsLists = [StepOne, StepTwo, StepThree, StepFour, StepFive, StepSix,StepSeven]


sad = StepTariffOne(StepsLists)

