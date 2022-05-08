using System;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class GenerationLinksPage
    {
        internal GenerationLinksPage AddNameLink(string nameOfLink)
        {
            //ввести название короткой ссылки
            var inputNameLink = new WebItem("//input[@name='tag']", "Ввод названия ссылки");
            inputNameLink.SendKeys(nameOfLink);
            return new GenerationLinksPage();
        }

        internal GenerationLinksPage AddLink(string link)
        {
            //ввести ссылку на которую будет создана короткая ссылка 
            var inputLink = new WebItem("//input[@name='url']", "Ввод ссылки внешнего ресурса");
            inputLink.SendKeys(link);
            return new GenerationLinksPage();
        }
        internal PortalHomePage logo()
        {
            //перейти в грид по бизнесам
            var grid = new WebItem("//div[@class='logo-container']", "Переход в грид по бизнесам");
            grid.Click();
            return new PortalHomePage();
        }
        
        public LeftMenu LeftMenu => new LeftMenu();

        internal GenerationLinksPage GoToShortLink(string nameOfLink)
        {
            //находим положение в контейнере по имени
            var linkContainer = new WebItem("//div[@class='cards-container']", "Контейнер ссылок");
            int count = linkContainer.CountOfTheElement("//div[@class='card']");
            var shortUrl = new WebItem("//div[@class='card'][" + count + "]//div[@name='link-short-path']", "Короткая ссылка");
            //копируем текст внутри карточки с коротким путем ссылки
            string shortLink = shortUrl.InnerText();
            //переходим по ссылке 
            DriverActions.GoToUrl(shortLink);
            //возвращаемся обратно на сайт и обновляем страницу
            DriverActions.Back();
            DriverActions.Refresh();
            return new GenerationLinksPage();
        }

        internal string GetNameOfFirstLink()
        {
            //получаем имя ссылки,если она есть, если нет вернем null и возвращаемся в грид по бизнесам
            var cardsContainer = new WebItem("//div[@class='cards-container']", "Контейнер карточек");
            if (cardsContainer.isDisplayedElementIn("//div[@class='card-field__text']"))
            {
                var firstLinkCard = new WebItem("//div[@class='card-field__text']", "Первая карточка с ссылкой");
                string txt = firstLinkCard.GetAttribute("innerText");
                logo();
                return txt;
            }
            logo();
            return null;
        }

        internal GenerationLinksPage ClickDeleteLink()
        {
            //нажимать удалить
            var buttonDeleteLink = new WebItem("//button[@class='delete-btn-cross']", "Крестик который удаляет ссылку");
            buttonDeleteLink.Click();
            buttonDeleteLink.WaitElementDisplayed();
            var buttonAccept = new WebItem("//button[@class='ui-btn ui-btn-success']//span[@class='ui-btn-text']", "Подтвердить удаление");
            buttonAccept.Click();
            buttonAccept.WaitElementDisplayed();
            return new GenerationLinksPage();
        }

        internal bool isDeletedLink(string name)
        {
            //проверка удален ли бизнес (есть ли бизнес с таким именем)
            var cardsContainer = new WebItem("//div[@class='cards-container']", "Контейнер карточек");
    
            if (cardsContainer.isDisplayedElementIn("//div[@class='card-field__text']"))
            {
                var cardLink = new WebItem("//div[@class='card-field__text']", "Первая карточка ссылки");
                //string txt = cardLink.GetAttribute("innerText");
                if (cardLink.InnerText().Contains(name))
                    return false;
                return true;
            }
            return true;
        }

        internal GenerationLinksPage ClickCreateLink()
        {
            //нажать создать ссылку 
            var buttonCreateLink = new WebItem("//input[@class='ui-btn ui-btn-success'][@value='Создать короткую ссылку']", "Кнопка создать короткую ссылку");
            buttonCreateLink.Click();
            buttonCreateLink.WaitElementDisplayed();
            return new GenerationLinksPage();
        }

        internal bool isCreatedLink(string name)
        {
            //проверить создана ли ссылка с таким именем
            var cardsContainer = new WebItem("//div[@class='cards-container']", "Контейнер ссылок");
            return cardsContainer.isDisplayedElementIn("//div[@class='card-field__text'][contains(text(),'" + name + "')]");
            //var cardLink = new WebItem("//div[@class='card-field__text'][contains(text(),'"+name+"')]", "Созданная карточка ссылки");
            //string txt = cardLink.GetAttribute("innerText");
            //if(txt.Contains(name))
            //    return true;
            //return false;
        }
    }
}

