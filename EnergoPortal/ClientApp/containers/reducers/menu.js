const horisontalMenu = [
    { id: "1", name: "Схема", href: "/", subId: [],},
    { id: "2", name: "Справочник", href: "#", subId: [],},
    { id: "3", name: "Инструменты", href: "#", subId: [],},
    { id: "3-1", name: "Все активные пользователи AD", href: "#", subId: [], parentId:"3" },
    { id: "3-2", name: "VLAN новой сети", href: "#", subId: [], parentId: "3" },
    
];


const addSub = (menu, parentId, id) => {
    return menu.forEach(el => {
        if (el.id === parentId) {
            el.subId.push(id);
        }
    });
};
horisontalMenu.forEach(el => {
    if (typeof el.parentId != undefined) {
        addSub(horisontalMenu, el.parentId, el.id)
    };
});


export default horisontalMenu;