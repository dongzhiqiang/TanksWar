-- BaseContainer.lua
-- Author : Dzq
-- Date : 2017-10-10
-- Last modification : 2017-10-10
-- Desc: BaseContainer 牌容器基类
BaseContainer = Class();
  
function BaseContainer:Ctor(go)
	if go == nil or go == "null" then
		util.LogError("创建失败 go 为空")
		return
	end
	self.m_type = ContainerType.NONE
	self.m_go = go
	self.m_tran = self.m_go.transform
	self.m_cards = false
	self.m_cardsItem = {}
	self.m_cached = false
	self.m_owner = false
	self.m_vCfg = false
end

function BaseContainer:Cache()
	-- util.LogError("cache -----")
	if self.m_cached then
		return
	end

	local num = self.m_tran.childCount-1
	for i=0, num do
		local go = self.m_tran:GetChild(i).gameObject
		go.name = "card"..(i+1)
		local c = Card.New(go)
		c:Init(self)
		self:AddItem(c)
	end

	self.m_cached = true
end

function BaseContainer:GetItemByIdx(idx)
	
	self:Cache()

	if idx > #self.m_cardsItem or idx < 1 then
		return
	end
	return self.m_cardsItem[idx]
end

function BaseContainer:GetItemCount()
	return #self.m_cardsItem
end

function BaseContainer:GetCardsCount()
	return #self.m_cards
end

function BaseContainer:SetCount( count )
	self:Cache()
	if count == 0 then
		self.m_go.gameObject:SetActive(false)
		return
	else
		self.m_go.gameObject:SetActive(true)
	end

	local curCount = #self.m_cardsItem
	local s
	-- log("curCount -- "..curCount..' | count -- '..count)
	if count < curCount then
		-- log("self.m_cardsItem count -- "..#self.m_cardsItem)
		for i = curCount, count+1, -1 do
			s = self.m_cardsItem[i]
			destroy(s:GetGameObject())
			table.remove(self.m_cardsItem, i)
		end
		-- log("self.m_cardsItem count 2 -- "..#self.m_cardsItem)
	elseif count > curCount then
		for i = curCount, count-1 do
			-- log("curCount--"..curCount..' #self.m_cardsItem--'..#self.m_cardsItem)
			local tempGo = self.m_cardsItem[curCount]:GetGameObject()
			local c = self:CreateCardItem(tempGo, i)
			self:AddItem(c)
		end
	end

end

--创建牌item
function BaseContainer:CreateCardItem(tempGo, idx)
	local g = GameObject.Instantiate(tempGo)
	g.transform:SetParent(self.m_go.transform)
	g.name = "card"..(idx+1)
	local c = Card.New(g)
	c:Init(self)
	c:SetScale(tempGo.transform.localScale)	
	return c
end

--添加牌值
function BaseContainer:AddNum(num)
	if not self.m_cards then
		self.m_cards = {}
	end
	self.m_cards[#self.m_cards+1] = num
end

--移除牌值
function BaseContainer:RemoveNum(num)
	for i=1, #self.m_cards do
		if num == self.m_cards[i] then
			table.remove(self.m_cards, i)
			break
		end
	end
end

--添加牌item
function BaseContainer:AddItem(cardItem)
	if not self.m_cardsItem then
		self.m_cardsItem = {}
	end
	self.m_cardsItem[#self.m_cardsItem+1] = cardItem
end

--移除牌item
function BaseContainer:RemoveItem(item)
	for i=1, #self.m_cardsItem do
		if item == self.m_cardsItem[i] then
			self.m_cardsItem[i]:Destroy()
			table.remove(self.m_cardsItem, i)
			break
		end
	end
end

--添加一个牌
function BaseContainer:AddCard(cardNum)

	--开始没牌时要处理下 使用的是第一个已有的牌 之后在新创建
	local cardItem 
	if #self.m_cards == 0 then
		--显示牌
		self:SetCount(1)
		self:GetItemByIdx(1)
		self:AddNum(cardNum)
		cardItem = self:GetItemByIdx(1)
	else
		self:AddNum(cardNum)
		cardItem = self:CreateCardItem(self:GetItemByIdx(1):GetGameObject(), self:GetItemCount())
		self:AddItem(cardItem)
	end
	
	cardItem:SetCard(cardNum)

	self:OnAddCard(cardItem)

	return cardItem
end

function BaseContainer:RemoveCard(cardItem)
	local tempRemove = {}

	for k,v in pairs(self.m_cardsItem) do
		if cardItem == v then
			tempRemove[#tempRemove+1] = v
			break
		end
	end

	for i=1, #tempRemove do
		self:RemoveNum(tempRemove[i]:GetCard())
		self:RemoveItem(tempRemove[i])
	end

	self:OnRemoveCard(tempRemove)
end

--删除牌 cardData table数组或number bKind 是否一种牌
-- 可 
-- 默认删除最后一张
-- 删除一个数组里的牌 各一张
-- 删除一个数组里的牌 各一种
-- 删除指定的一张牌
-- 删除指定的一种牌 
function BaseContainer:RemoveCardsEx(cardData, bKind)
	local tempRemove = {}

	if not cardData then	--没参数 默认移除最后一张
		tempRemove[#tempRemove+1] = self.m_cardsItem[#self.m_cardsItem]
	elseif type(cardData) == "table" then	--移除多张
		for i=1, #cardData do
			local cardId = cardData[i]
			for j=1, #self.m_cardsItem do
				if self.m_cardsItem[j] == cardId then
					tempRemove[#tempRemove+1] = self.m_cardsItem[j]
					if not bKind then
						break
					end
				end
			end
		end
	elseif type(cardData) == "number" then	--移除指定牌
		for i=1, #self.m_cardsItem do
			if self.m_cardsItem[i] == cardData then
				tempRemove[#tempRemove+1] = self.m_cardsItem[i]
				if not bKind then
					break
				end
			end
		end
	end
	log("tempRemove num -- "..#tempRemove)

	for i=1, #tempRemove do
		self:RemoveNum(tempRemove[i]:GetCard())
		self:RemoveItem(tempRemove[i])
	end

	self:OnRemoveCard(tempRemove)
end

function BaseContainer:RemoveCardsInEnd(num)
	
	local tempRemove = {}

	if type(num) == "number" then
		for i=1, num do
			if i <= #self.m_cardsItem then
				tempRemove[#tempRemove+1] = self.m_cardsItem[#self.m_cardsItem-(i-1)]
			end
		end
	end

	for i=1, #tempRemove do
		self:RemoveNum(tempRemove[i]:GetCard())
		self:RemoveItem(tempRemove[i])
	end

	self:OnRemoveCard(tempRemove)
end

function BaseContainer:HideCardByIdx(idx)
	local tempItems = {}
	for i=1, #self.m_cardsItem do
		if self.m_cardsItem[i]:IsActive() then
			tempItems[#tempItems+1] = self.m_cardsItem[i]	--得到没有隐藏的
		end
	end
	idx = idx or #tempItems
	if idx > #tempItems then
		util.LogError("HideCardByIdx idx 超出范围 idx:"..idx)
		return
	end

	tempItems[idx]:SetActive(false)
end

--添加一组牌
-- cardData 数据结构
-- {
-- 	cards = {0x31,0x32,0x33},
-- 	shwoType = CardShowType.CHI,
-- 	otherId = 1234
-- }
function BaseContainer:AddCardGroup(cardData)
	local cardItemGroup = {}
	log("addCardGroup -- cards num - "..#cardData.cards.." showType - "..cardData.showType.." cardOtherId - "..cardData.otherId)

	for i=1, #cardData.cards do
		-- log("AddCard -- "..cardData.cards[i])
		local cardItem = self:AddCard(cardData.cards[i])
		-- log("cardItem name -- "..cardItem:GetCardName().." go name --"..cardItem:GetGameObject().name)
		cardItemGroup[#cardItemGroup+1] = cardItem
	end

	self:OnAddCardGroup(cardData, cardItemGroup)

	return cardItemGroup
end

function BaseContainer:SetOwner(player)
	self.m_owner = player
end

function BaseContainer:Init(param)
	----处理传入参数
	local cards = {}
	if type(param) == "table" then
		cards = param
	elseif type(param) == "number" then
		for i=1, param do
			cards[#cards+1] = 0
		end
	else
		util.LogError("初始化牌错误 传入类型不对")
	end

	self:OnInit(cards)

	self:Fresh()
end

function BaseContainer:IsMyHandsCard()
	if PlayerMgr.IsMyself(self.m_owner) and self.m_type == ContainerType.HAND then
		return true
	end
	return false
end

function BaseContainer:GetType()
	return self.m_type
end

function BaseContainer:Update()
	return self:OnUpdate()
end

function BaseContainer:Fresh()
	-- log("BaseContainer:OnFresh ----- ")
	if not self.m_vCfg then
		logError("没找到sit["..sit.."]对应配置")
		return
	end

	return self:OnFresh()
end

function BaseContainer:OnInit()
end

function BaseContainer:OnAddCard(cardItem)
end

function BaseContainer:OnAddCardGroup(cardData, cardItemGroup)
end

function BaseContainer:OnRemoveCard(removeCards)
	
end

function BaseContainer:OnShowCards(bAni)
end

function BaseContainer:OnUpdate()
end

function BaseContainer:OnFresh()
end

function BaseContainer:UnLoad()
end